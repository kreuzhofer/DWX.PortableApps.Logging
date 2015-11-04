using System;
using System.Collections.Generic;

namespace DWX.PortableApps.Logging
{
    public class ConcatenatedLogger : IPortableLogger
    {
        private IList<IPortableLogger> _loggers;

        public ConcatenatedLogger(IList<IPortableLogger> loggers)
        {
            _loggers = loggers;
        }

        public string Name { get; private set; }

        public void Trace(string message, Exception ex = null)
        {
            Log(LogLevel.Trace, message, ex);
        }

        public void Trace(string message, params object[] ps)
        {
            Log(LogLevel.Trace, message, ps);
        }

        public void Debug(string message, Exception ex = null)
        {
            Log(LogLevel.Debug, message, ex);
        }

        public void Debug(string message, params object[] ps)
        {
            Log(LogLevel.Debug, message, ps);
        }

        public void Info(string message, Exception ex = null)
        {
           Log(LogLevel.Info, message, ex);
        }

        public void Info(string message, params object[] ps)
        {
            Log(LogLevel.Info, message, ps);
        }

        public void Warn(string message, Exception ex = null)
        {
            Log(LogLevel.Warn, message, ex);
        }

        public void Warn(string message, params object[] ps)
        {
            Log(LogLevel.Warn, message, ps);
        }

        public void Error(string message, Exception ex = null)
        {
            Log(LogLevel.Error, message, ex);
        }

        public void Error(string message, params object[] ps)
        {
            Log(LogLevel.Error, message, ps);
        }

        public void Fatal(string message, Exception ex = null)
        {
            Log(LogLevel.Fatal, message, ex);
        }

        public void Fatal(string message, params object[] ps)
        {
            Log(LogLevel.Fatal, message, ps);
        }

        public void Log(LogLevel logLevel, string message, params object[] ps)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(logLevel, string.Format(message, ps));
            }
        }

        public void TrackMetric(string metricName, double metricValue)
        {
            foreach (var logger in _loggers)
            {
                logger.TrackMetric(metricName, metricValue);
            }
        }

        public void TrackEvent(string eventName)
        {
            foreach (var logger in _loggers)
            {
                logger.TrackEvent(eventName);
            }
        }

        public void TrackPageView(string pageName)
        {
            foreach (var logger in _loggers)
            {
                logger.TrackPageView(pageName);
            }
        }

        public void Log(LogLevel logLevel, string message, Exception exception, Dictionary<string, string> propertyBag = null)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(logLevel, message, exception, propertyBag);
            }
        }
    }
}