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
        private readonly List<string> TrackedEvents = new List<string>
        {
            "Microsoft.AspNetCore.Hosting",
            "Microsoft-AspNetCore-Server-Kestrel",
        };

        public readonly ConcurrentDictionary<string, EventSource> EventSources =
            new ConcurrentDictionary<string, EventSource>();

        private string Name;

        public CountersEventListener(string name)
        {
            this.Name = name;
        }

        private void Log(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}:{Name}: {message}");
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource == null || !TrackedEvents.Contains(eventSource.Name))
            {
                return;
            }

            this.Log($"{eventSource.ToString()} has been created");
            EventSources[eventSource.Name] = eventSource;
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventName is null || !eventData.EventName.Equals("EventCounters") ||
                eventData.Payload == null)
            {
                return;
            }

            if (!this.TrackedEvents.Contains(eventData.EventSource.Name))
            {
                return;
            }

            this.Log($"{eventData.EventSource} event has been written");
        }

        public void DisableEvents()
        {
            foreach (var keyValuePair in EventSources)
            {
                DisableEvents(keyValuePair.Value);
            }

            this.Log($"Disabled all events {string.Join(",", EventSources.Keys)}");
        }


        /// <summary>
        /// invoke CountersEventListener.Instance.EnableEvents
        /// </summary>
        public void EnableEvents()
        {
            var args = new Dictionary<string, string?>
            {
                ["EventCounterIntervalSec"] = "5"
            };

            foreach (var keyValuePair in EventSources)
            {
                EnableEvents(keyValuePair.Value, EventLevel.Verbose, EventKeywords.All, args);
            }

            this.Log($"Enabled all events {string.Join(",", EventSources.Keys)}");
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
            var timeToDisableC2 = timeToEnable.Multiply(2);
            var timeToDisableC1 = timeToEnable.Multiply(3);

            var c1 = new CountersEventListener("c1");
            Task.Run(
                () =>
                {
                    Thread.Sleep(timeToEnable);
                    c1.EnableEvents();
                });

            var c2 = new CountersEventListener("c2");
            Task.Run(
                () =>
                {
                    Thread.Sleep(timeToDisableC2);
                    c2.DisableEvents();
                });

            Task.Run(
                () =>
                {
                    Thread.Sleep(timeToDisableC1);
                    c1.DisableEvents();
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