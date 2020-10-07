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
    public class GetKeySets : BaseQuery<IEnumerable<KeySet>>
    {
        private const int PAGE_SIZE = 10;

        public GetKeySetParams QueryParams { get; private set; }

        public static GetKeySets Create(GetKeySetParams queryParams)
        {
            return new GetKeySets
            {
                QueryParams = queryParams
            };
        }

        protected async override Task<IEnumerable<KeySet>> ExecuteInternal(IQueryContext queryContext)
        {
            var context = ((BusContext)queryContext).DataContext;
            var keySets = context.KeySets.AsQueryable();
            if (!string.IsNullOrWhiteSpace(QueryParams.SearchString))
            {
                keySets = keySets.Where(e => e.Id.Contains(QueryParams.SearchString));
            }
            keySets = keySets.OrderBy(e => e.Id);
            if (QueryParams.Page.HasValue)
            {
                keySets = keySets.Skip((QueryParams.Page.Value - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            }
            return await keySets.ToListAsync();
        }
    }
}
