namespace Snegir.Core.Exceptions
{
    public class SnegirException: Exception
    {
        public SnegirException(string message) : base(message) { }

        public SnegirException(string message, Exception innerException) : base(message, innerException) { }
    }
}
