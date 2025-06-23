using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Encoding = System.Text.Encoding;

namespace WebApplication2
{
    public class CountersEventListener : EventListener
    {
        private const string TrackedEvent = "Microsoft-AspNetCore-Server-Kestrel";
        private EventSource? _trackedEventSource;
        private readonly string _name;

        public CountersEventListener(string name)
        {
            this._name = name;
        }

        private void Log(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss.fff}:{this._name}: {message}");
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (TrackedEvent != eventSource.Name)
            {
                return;
            }

            this.Log($"{eventSource} has been created");
            this._trackedEventSource = eventSource;
            
            var args = new Dictionary<string, string?>
            {
                ["EventCounterIntervalSec"] = "5"
            };
            
            this.EnableEvents(this._trackedEventSource, EventLevel.Verbose, EventKeywords.All, args);
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventName is null || eventData.Payload is null)
                return;

            // if (!eventData.EventName.Equals("EventCounters"))
            //     return;
                
            if (TrackedEvent != eventData.EventSource.Name)
                return;

            this.Log($"{eventData.EventSource}:{eventData.EventName} event has been written");
        }

        public void DisableEvent()
        {
            if (this._trackedEventSource is null)
                return;
            
            this.DisableEvents(this._trackedEventSource);

            this.Log($"*** Disabled event {this._trackedEventSource}");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.Map(new PathString("/myhandler"), (Action<IApplicationBuilder>)(b => b.UseMyHandler()));
            var timeToEnable = TimeSpan.FromSeconds(10);
            var timeToDisableC1 = timeToEnable.Multiply(1);
            var timeToDisableC2 = timeToEnable.Multiply(2);
            var timeToDisableC3 = timeToEnable.Multiply(3);

            Console.WriteLine("starting");
            var c1 = new CountersEventListener("c1");
            var c2 = new CountersEventListener("c2");
            var c3 = new CountersEventListener("c3");

            Task.Run(() =>
            {
                Console.WriteLine("*** IN THREAD 1");
                Thread.Sleep(timeToDisableC1);
                Console.WriteLine("*** AFTER SLEEP 1");
                c1.DisableEvent();
            });

            Task.Run(() =>
            {
                Console.WriteLine("*** IN THREAD 2");
                Thread.Sleep(timeToDisableC2);
                Console.WriteLine("*** AFTER SLEEP 2");
                c2.DisableEvent();
            });
            
            Task.Run(() =>
            {
                Console.WriteLine("*** IN THREAD 3");
                Thread.Sleep(timeToDisableC3);
                Console.WriteLine("*** AFTER SLEEP 3");
                c3.DisableEvent();
            });

            Console.WriteLine("running");

            Task.Run(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:5165");
                while (true)
                {
                    httpClient.GetAsync("/myhandler").Result.EnsureSuccessStatusCode();
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            });
            app.Run();
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyHandler>();
        }
    }

    public class MyHandler
    {
        public MyHandler(RequestDelegate next)
        {
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes("Hello, world."));
        }
    }
}