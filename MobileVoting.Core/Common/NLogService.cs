using NLog;

namespace MobileVoting.Core.Common
{
    public interface ILogService<T>
    {
        Logger Logger { get; }
    }

    public class NLogService<T> : ILogService<T>
    {
        public Logger Logger { get; private set; }

        public NLogService()
        {
            Logger = LogManager.GetLogger(typeof(T).FullName);
        }
    }
}