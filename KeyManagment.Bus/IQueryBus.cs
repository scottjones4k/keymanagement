using KeyManagment.Bus.Queries;
using System.Threading.Tasks;

namespace KeyManagment.Bus
{
    public interface IQueryBus
    {
        Task<IQueryResponse<T>> ExecuteQuery<T>(BaseQuery<T> query);
    }
}