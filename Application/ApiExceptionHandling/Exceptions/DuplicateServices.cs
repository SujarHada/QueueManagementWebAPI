
namespace Application.ApiExceptionHandling.Exceptions
{
    public class DuplicateServices : Exception
    { 
    public  DuplicateServices(string ServiceName) : base($"An service named {ServiceName} exists already.")
    {
    }

    public DuplicateServices(string ServiceName, string ServiceDescription) : base($"An service wtih a different name but same description exists already.")
    {
    }

    }
}

