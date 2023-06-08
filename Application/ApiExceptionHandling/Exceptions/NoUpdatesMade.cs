
namespace Application.ApiExceptionHandling.Exceptions
{
    public class NoUpdatesMade : Exception
    {
        public NoUpdatesMade(string ServiceName) : base($"No updates made on {ServiceName}")
        {
        }
    }
}

