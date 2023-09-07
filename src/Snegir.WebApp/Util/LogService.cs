using Snegir.Core.Services;
using Serilog;

namespace Snegir.WebApp.Util
{
    public class LogService : ILogService
    {
        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Error(Exception ex, string message)
        {
            Log.Error(ex, message);
        }
    }
}
