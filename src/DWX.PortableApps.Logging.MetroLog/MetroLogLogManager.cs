using MetroLog;

namespace DWX.PortableApps.Logging.MetroLogger
{
    /// <summary>
    /// The windows store log manager.
    /// </summary>
    public class MetroLogLogManager : IPortableLogManager
    {
        /// <summary>
        /// The create logger.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="IPortableLogger"/>.
        /// </returns>
        public IPortableLogger CreateLogger(string name)
        {
            return new MetroLogLogger(name, LogManagerFactory.CreateLogManager().GetLogger(name));
        }

        public IPortableLogger CreateLogger<T>()
        {
            return new MetroLogLogger(typeof(T).Name, LogManagerFactory.CreateLogManager().GetLogger<T>());
        }

        public void SetLogLevel(LogLevel logLevel)
        {
            
        }
    }
}
