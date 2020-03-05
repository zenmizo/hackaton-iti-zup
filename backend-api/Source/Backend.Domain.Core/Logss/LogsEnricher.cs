using Serilog.Core;
using Serilog.Events;
using System;

namespace Backend.Domain.Core.Logs
{
    public class LogsEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddOrUpdateProperty(CreateProperty(propertyFactory, "uid", Guid.NewGuid().ToString()));

            //logEvent.RemovePropertyIfPresent("Elapsed");
            //logEvent.RemovePropertyIfPresent("ParentId");
            //logEvent.RemovePropertyIfPresent("RequestId");
            //logEvent.RemovePropertyIfPresent("RequestMethod");
            //logEvent.RemovePropertyIfPresent("RequestPath");
            //logEvent.RemovePropertyIfPresent("SourceContext");
            //logEvent.RemovePropertyIfPresent("SpanId");
            //logEvent.RemovePropertyIfPresent("StatusCode");
            //logEvent.RemovePropertyIfPresent("TraceId");
        }

        private static LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory, string key, object value)
        {
            return propertyFactory.CreateProperty(key, value);
        }
    }
}
