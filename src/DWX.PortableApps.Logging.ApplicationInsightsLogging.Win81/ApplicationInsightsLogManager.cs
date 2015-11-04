using Microsoft.ApplicationInsights;

namespace DWX.PortableApps.Logging.ApplicationInsightsLogging.Win81
{
    public class ApplicationInsightsLogManager : IPortableLogManager
    {
        public ApplicationInsightsLogManager(TelemetryClient telemetryClient)
        {
            _telemetry = telemetryClient;
        }

        private readonly TelemetryClient _telemetry;
        private LogLevel _logLevel = LogLevel.Trace;
        public TelemetryClient TelemetryClient { get { return _telemetry; } }
        public LogLevel LogLevel { get {  return _logLevel;} }

        public IPortableLogger CreateLogger(string name)
        {
            return new ApplicationInsightsLogger(name, this);
        }

        public IPortableLogger CreateLogger<T>()
        {
            return new ApplicationInsightsLogger(typeof (T).Name, this);
        }

        public void SetLogLevel(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }
    }
}