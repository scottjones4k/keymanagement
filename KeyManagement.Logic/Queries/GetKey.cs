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
    public class GetKey : BaseQuery<Key>
    {
        public GetKeyParams QueryParams { get; private set; }

        public static GetKey Create(GetKeyParams queryParams)
        {
            return new GetKey
            {
                QueryParams = queryParams
            };
        }

        protected async override Task<Key> ExecuteInternal(IQueryContext queryContext)
        {
            var context = ((BusContext)queryContext).DataContext;
            return await context.Keys.FirstOrDefaultAsync(e => e.Id == QueryParams.KeyId);
        }
    }
}
