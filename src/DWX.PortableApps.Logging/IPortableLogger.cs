using System;
using System.Collections.Generic;

namespace DWX.PortableApps.Logging
{
    /// <summary>
    /// The Logger interface.
    /// </summary>
    public interface IPortableLogger
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        void Trace(string message, Exception ex = null);

        void Trace(string message, params object[] ps);

        void Debug(string message, Exception ex = null);

        void Debug(string message, params object[] ps);

        void Info(string message, Exception ex = null);

        void Info(string message, params object[] ps);

        void Warn(string message, Exception ex = null);

        void Warn(string message, params object[] ps);

        void Error(string message, Exception ex = null);

        void Error(string message, params object[] ps);

        void Fatal(string message, Exception ex = null);

        void Fatal(string message, params object[] ps);

        void Log(LogLevel logLevel, string message, Exception ex = null, Dictionary<string, string> propertyBag = null);

        void TrackMetric(string metricName, double metricValue);
        void TrackEvent(string eventName);
        void TrackPageView(string pageName);
    }
}
