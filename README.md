When I run this for about 30 seconds, this is the output I see. Although we only ever enable events for listener `c1`, the `OnEventWritten` callback of `c2` still gets called. Disabling events for `c2` does nothing. But, disabled events for `c1` disables them for both `c1` and `c2`

```
2025-06-20 22:42:12.787:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) has been created
2025-06-20 22:42:12.792:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) has been created
2025-06-20 22:42:12.822:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) has been created
2025-06-20 22:42:12.823:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) has been created
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5165
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\john.mancini\Desktop\WebApplication2\WebApplication2
2025-06-20 22:42:22.820:c1: Enabled all events Microsoft-AspNetCore-Server-Kestrel,Microsoft.AspNetCore.Hosting
2025-06-20 22:42:27.826:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.826:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.827:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.827:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.829:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.829:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.829:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.829:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.829:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:27.829:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:27.829:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:27.829:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:27.829:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:27.829:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:27.829:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:27.829:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:27.829:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:32.798:c2: Disabled all events Microsoft-AspNetCore-Server-Kestrel,Microsoft.AspNetCore.Hosting
2025-06-20 22:42:32.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.828:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.828:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.828:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.828:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.829:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.830:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.830:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.830:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.830:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:32.830:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:32.830:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:32.830:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:32.830:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:32.830:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:32.830:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:32.830:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:32.830:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:37.822:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.822:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.822:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.822:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.823:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.824:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.824:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.824:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.824:c1: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.824:c2: EventSource(Microsoft-AspNetCore-Server-Kestrel, bdeb4676-a36e-5442-db99-4764e2326c7d) event has been written
2025-06-20 22:42:37.824:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:37.824:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:37.824:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:37.824:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:37.824:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:37.824:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:37.825:c1: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:37.825:c2: EventSource(Microsoft.AspNetCore.Hosting, 9ded64a4-414c-5251-dcf7-1e4e20c15e70) event has been written
2025-06-20 22:42:42.792:c1: Disabled all events Microsoft-AspNetCore-Server-Kestrel,Microsoft.AspNetCore.Hosting
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```