using Domain.Entities;
namespace Application.ApiExceptionHandling.Responses
{
    public class ApiExceptionResponse<T>
    {
        private readonly Exception _exception;
        private ApiExceptionResponse<T> user;

        public string Message { get; set; }
        public T Response { get; set; }
        public ApiExceptionResponse(Exception exception)
        {
            _exception = exception;
            Message = _exception.Message;    
        }
        public ApiExceptionResponse(T res)
        {
            Response = res;
        } 
    }

}
