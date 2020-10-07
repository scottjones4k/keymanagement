namespace KeyManagment.Bus.Queries
{
    internal class QueryResponse<T> : IQueryResponse<T>
    {
        public IQuery<T> OriginalQuery { get; internal set; }

        public T Response { get; internal set; }
    }
}
