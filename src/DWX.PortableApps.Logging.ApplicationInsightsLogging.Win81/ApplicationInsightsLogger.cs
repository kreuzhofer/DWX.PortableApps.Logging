using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace DWX.PortableApps.Logging.ApplicationInsightsLogging.Win81
{
    public class ApplicationInsightsLogger : IPortableLogger
    {
        private TelemetryClient _telemetryClient;
        private string _name;
        private ApplicationInsightsLogManager _logManager;
        private string _user;
        private string _machine;
        private string _domain;

        private string GetHostName()
        {
            IReadOnlyList<HostName> hostNames = NetworkInformation.GetHostNames();
            HostName hostName = hostNames.FirstOrDefault(x => x.Type == HostNameType.DomainName);
            var parts = hostName.DisplayName.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            return parts.FirstOrDefault();
        }

        public ApplicationInsightsLogger(string name, ApplicationInsightsLogManager logManager)
        {
            _logManager = logManager;
            _telemetryClient = _logManager.TelemetryClient;
            _name = name;
            _machine = GetHostName();
            _user = CredentialCache.DefaultNetworkCredentials.UserName;
            _domain = CredentialCache.DefaultNetworkCredentials.Domain;
        }

        public string Name
        {
            get { return _name; }
        }

        public void Trace(string message, System.Exception ex = null)
        {
            Log(LogLevel.Trace, message, ex);
        }

        public void Trace(string message, params object[] ps)
        {
            Log(LogLevel.Trace, message, ps);
        }

        public void Debug(string message, System.Exception ex = null)
        {
            Log(LogLevel.Debug, message, ex);
        }

        public void Debug(string message, params object[] ps)
        {
            Log(LogLevel.Debug, message, ps);
        }

        public void Info(string message, System.Exception ex = null)
        {
            Log(LogLevel.Info, message, ex);
        }

        public void Info(string message, params object[] ps)
        {
            Log(LogLevel.Info, message, ps);
        }

        public void Warn(string message, System.Exception ex = null)
        {
            Log(LogLevel.Warn, message, ex);
        }

        public void Warn(string message, params object[] ps)
        {
            Log(LogLevel.Warn, message, ps);
        }

        public void Error(string message, System.Exception ex = null)
        {
            Log(LogLevel.Error, message, ex);
        }

        public void Error(string message, params object[] ps)
        {
            Log(LogLevel.Error, message, ps);
        }

        public void Fatal(string message, System.Exception ex = null)
        {
            Log(LogLevel.Fatal, message, ex);
        }

        public void Fatal(string message, params object[] ps)
        {
            Log(LogLevel.Fatal, message, ps);
        }

        public void Log(LogLevel logLevel, string message, System.Exception ex = null)
        {
            if (logLevel < _logManager.LogLevel)
            {
                return;
            }
            if (ex == null)
            {
                var tel = new TraceTelemetry(message, GetLevel(logLevel));
                tel.Properties.Add(new KeyValuePair<string, string>("Machine name", _machine));
                tel.Properties.Add(new KeyValuePair<string, string>("User name", _user));
                tel.Properties.Add(new KeyValuePair<string, string>("Domain name", _domain));
                _telemetryClient.TrackTrace(tel);
            }
            else
            {
                var tel = new ExceptionTelemetry(ex);
                tel.Properties.Add(new KeyValuePair<string, string>("Message", message));
                tel.Properties.Add(new KeyValuePair<string, string>("Machine name", _machine));
                tel.Properties.Add(new KeyValuePair<string, string>("User name", _user));
                tel.Properties.Add(new KeyValuePair<string, string>("Domain name", _domain));
                _telemetryClient.TrackException(tel);
            }
        }

        public void Log(LogLevel logLevel, string message, params object[] ps)
        {
            Log(logLevel, String.Format(message, ps));
        }

        public void TrackMetric(string metricName, double metricValue)
        {
            var tel = new MetricTelemetry(metricName, metricValue);
            tel.Properties.Add(new KeyValuePair<string, string>("Machine name", _machine));
            tel.Properties.Add(new KeyValuePair<string, string>("User name", _user));
            tel.Properties.Add(new KeyValuePair<string, string>("Domain name", _domain));
            _telemetryClient.TrackMetric(tel);
        }

        public void TrackEvent(string eventName)
        {
            var tel = new EventTelemetry(eventName);
            tel.Properties.Add(new KeyValuePair<string, string>("Machine name", _machine));
            tel.Properties.Add(new KeyValuePair<string, string>("User name", _user));
            tel.Properties.Add(new KeyValuePair<string, string>("Domain name", _domain));
            _telemetryClient.TrackEvent(tel);
        }

        public void TrackPageView(string pageName)
        {
            var tel = new PageViewTelemetry(pageName);
            tel.Properties.Add(new KeyValuePair<string, string>("Machine name", _machine));
            tel.Properties.Add(new KeyValuePair<string, string>("User name", _user));
            tel.Properties.Add(new KeyValuePair<string, string>("Domain name", _domain));
            _telemetryClient.TrackPageView(tel);
        }

        private SeverityLevel GetLevel(LogLevel logLevel)
        {
            SeverityLevel level;
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                    level = SeverityLevel.Verbose;
                    break;
                case LogLevel.Info:
                    level = SeverityLevel.Information;
                    break;
                case LogLevel.Warn:
                    level = SeverityLevel.Warning;
                    break;
                case LogLevel.Error:
                    level = SeverityLevel.Error;
                    break;
                case LogLevel.Fatal:
                    level = SeverityLevel.Critical;
                    break;
                default:
                    level = SeverityLevel.Verbose;
                    break;
            }
            return level;
        }
    }
}