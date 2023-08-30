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
    }
}
