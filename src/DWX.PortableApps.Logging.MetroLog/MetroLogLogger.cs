using System;
using MetroLog;

namespace DWX.PortableApps.Logging.MetroLogger
{
    /// <summary>
    /// The logger.
    /// </summary>
    public class MetroLogLogger : IPortableLogger
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroLogLogger"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="logger">
        /// The get logger.
        /// </param>
        public MetroLogLogger(string name, ILogger logger)
        {
            this.Name = name;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        public void Trace(string message, Exception ex = null)
        {
            this.logger.Trace(message, ex);
        }

        public void Trace(string message, params object[] ps)
        {
            this.logger.Trace(message, ps);            
        }

        public void Debug(string message, Exception ex = null)
        {
            this.logger.Debug(message, ex);
        }

        public void Debug(string message, params object[] ps)
        {
            this.logger.Debug(message, ps);
        }

        public void Info(string message, Exception ex = null)
        {
            this.logger.Info(message, ex);
        }

        public void Info(string message, params object[] ps)
        {
            this.logger.Info(message, ps);
        }

        public void Warn(string message, Exception ex = null)
        {
            this.logger.Warn(message, ex);
        }

        public void Warn(string message, params object[] ps)
        {
            this.logger.Warn(message, ps);
        }

        public void Error(string message, Exception ex = null)
        {
            this.logger.Error(message, ex);
        }

        public void Error(string message, params object[] ps)
        {
            this.logger.Error(message, ps);
        }

        public void Fatal(string message, Exception ex = null)
        {
            this.logger.Fatal(message, ex);
        }

        public void Fatal(string message, params object[] ps)
        {
            this.logger.Fatal(message, ps);
        }

        public void Log(LogLevel logLevel, string message, Exception ex = null)
        {
            MetroLog.LogLevel metroLogLevel;
            MetroLog.LogLevel.TryParse(logLevel.ToString(), out metroLogLevel);
            this.logger.Log(metroLogLevel, message, ex);
        }

        public void Log(LogLevel logLevel, string message, params object[] ps)
        {
            MetroLog.LogLevel metroLogLevel;
            MetroLog.LogLevel.TryParse(logLevel.ToString(), out metroLogLevel);
            this.logger.Log(metroLogLevel, message, ps);
        }
        public void TrackMetric(string metricName, double metricValue)
        {
            Trace("Metric|{0}|{1}", metricName, metricValue);
        }

        public void TrackEvent(string eventName)
        {
            Log(LogLevel.Trace, "Event|{0}", eventName);
        }

        public void TrackPageView(string pageName)
        {
            Log(LogLevel.Trace, "PageView|{0}", pageName);
        }
    }
}
