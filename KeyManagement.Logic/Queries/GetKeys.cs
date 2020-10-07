using KeyManagement.Repository;
using KeyManagement.Repository.Entities;
using KeyManagment.Bus;
using KeyManagment.Bus.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyManagement.Logic.Queries
{
    public class GetKeys : BaseQuery<IEnumerable<Key>>
    {
        public GetKeysParams QueryParams { get; private set; }

        public static GetKeys Create(GetKeysParams queryParams)
        {
            return new GetKeys
            {
                QueryParams = queryParams
            };
        }

        protected async override Task<IEnumerable<Key>> ExecuteInternal(IQueryContext queryContext)
        {
            var context = ((BusContext)queryContext).DataContext;
            return await context.Keys.Where(e => e.KeySetId == QueryParams.KeySetId).ToListAsync();
        }
    }
}
