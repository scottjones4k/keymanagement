using KeyManagment.Bus.Queries;
using System.Threading.Tasks;

namespace KeyManagment.Bus
{
    public class QueryBus : IQueryBus
    {
        private readonly IQueryContext _queryContext;

        public QueryBus(IQueryContext queryContext)
        {
            _queryContext = queryContext;
        }

        public async Task<IQueryResponse<T>> ExecuteQuery<T>(BaseQuery<T> query)
        {
            return new QueryResponse<T>
            {
                OriginalQuery = query,
                Response = await query.Execute(_queryContext)
            };
        }
    }
}
