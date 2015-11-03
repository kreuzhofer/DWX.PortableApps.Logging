namespace DWX.PortableApps.Logging
{
    public interface IPortableLogManager
    {
        IPortableLogger CreateLogger(string name);
        IPortableLogger CreateLogger<T>();
        void SetLogLevel(LogLevel logLevel);
    }
}
