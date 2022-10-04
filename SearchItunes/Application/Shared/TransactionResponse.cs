namespace Itunes.Application.Shared
{
    public class TransactionResponse<T>
    {
        protected internal TransactionResponse(T result, string message, TransactionStatus status)
        {
            Result = result;
            Message = message;
            Status = status;
        }

        public T Result { get; }
        public TransactionStatus Status { get; set; }
        public string Message { get; }
    }

    public class TransactionResponse : TransactionResponse<string>
    {
        protected TransactionResponse(string message, TransactionStatus status)
            : base(null, message, status)
        {
        }

        public static TransactionResponse Ok(string message = "Success")
        {
            return new TransactionResponse(message, TransactionStatus.Ok);
        }

        public static TransactionResponse<T> Ok<T>(T result, string message = "Success")
        {
            return new TransactionResponse<T>(result, message, TransactionStatus.Ok);
        }

        public static TransactionResponse<T> Created<T>(T result)
        {
            return new TransactionResponse<T>(result, null, TransactionStatus.Created);
        }

        public static TransactionResponse<T> NotFound<T>(T result, string errorMessage)
        {
            return new TransactionResponse<T>(result, errorMessage, TransactionStatus.NotFound);
        }
    }
}