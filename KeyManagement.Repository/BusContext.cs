using KeyManagment.Bus;

namespace KeyManagement.Repository
{
    public class BusContext : ICommandContext, IQueryContext
    {
        public BusContext(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public DataContext DataContext { get; private set; }
    }
}
