namespace BookLibraryREST.Services
{
    public enum ServiceError
    {
        None,
        NotFound,
        BadRequest
    }

    public class ServiceResult
    {
        protected ServiceResult(ServiceError error, string? message)
        {
            Error = error;
            Message = message;
        }

        public ServiceError Error { get; }
        public string? Message { get; }
        public bool IsSuccess => Error == ServiceError.None;

        public static ServiceResult Success()
        {
            return new ServiceResult(ServiceError.None, null);
        }

        public static ServiceResult NotFound(string message)
        {
            return new ServiceResult(ServiceError.NotFound, message);
        }

        public static ServiceResult BadRequest(string message)
        {
            return new ServiceResult(ServiceError.BadRequest, message);
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        private ServiceResult(T? value, ServiceError error, string? message) : base(error, message)
        {
            Value = value;
        }

        public T? Value { get; }

        public new static ServiceResult<T> Success(T value)
        {
            return new ServiceResult<T>(value, ServiceError.None, null);
        }

        public new static ServiceResult<T> NotFound(string message)
        {
            return new ServiceResult<T>(default, ServiceError.NotFound, message);
        }

        public new static ServiceResult<T> BadRequest(string message)
        {
            return new ServiceResult<T>(default, ServiceError.BadRequest, message);
        }
    }
}
