using System.Collections.Generic;

namespace DWX.PortableApps.Logging
{
    public class ConcatenatingLogManager : IPortableLogManager
    {
        private readonly IPortableLogManager[] _logManagers;

        public ConcatenatingLogManager(IPortableLogManager[] logManagers)
        {
            _logManagers = logManagers;
        }

        public IPortableLogger CreateLogger(string name)
        {
            IList<IPortableLogger> loggers = new List<IPortableLogger>();
            foreach (var logManager in _logManagers)
            {
                var logger = logManager.CreateLogger(name);
                loggers.Add(logger);
            }
            return new ConcatenatedLogger(loggers);
        }

        public IPortableLogger CreateLogger<T>()
        {
            return CreateLogger(typeof (T).Name);
        }

        public void SetLogLevel(LogLevel logLevel)
        {
            foreach (var logManager in _logManagers)
            {
                logManager.SetLogLevel(logLevel);
            }
        }
    }
}