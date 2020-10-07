using System.Threading.Tasks;

namespace KeyManagment.Bus.Queries
{
    public abstract class BaseQuery<T> : IQuery<T>
    {
        internal async Task<T> Execute(IQueryContext queryContext)
        {
            return await ExecuteInternal(queryContext);
        }

        protected abstract Task<T> ExecuteInternal(IQueryContext queryContext);
    }
}
