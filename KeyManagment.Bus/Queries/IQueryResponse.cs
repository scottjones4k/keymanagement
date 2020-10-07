namespace KeyManagment.Bus.Queries
{
    public interface IQueryResponse<T>
    {
        IQuery<T> OriginalQuery { get; }
        T Response { get; }
    }
}
