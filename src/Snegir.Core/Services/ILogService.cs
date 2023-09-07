namespace Snegir.Core.Services
{
    public interface ILogService
    {
        void Information(string message);

        void Error(Exception ex, string message);
    }
}
