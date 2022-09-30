namespace SearchItunes.Data
{
    public class RepoResponse<T>
    {
        public RepoResponseStatus Status { get; set; }
        public T Data { get; set; }
    }

    public enum RepoResponseStatus
    {
        Success,
        Error,
        RecordNotFound
    }
}