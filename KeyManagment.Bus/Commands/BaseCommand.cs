using System.Threading.Tasks;

namespace KeyManagment.Bus.Commands
{
    public abstract class BaseCommand : ICommand
    {
        internal async Task Execute(ICommandContext commandContext)
        {
            await ExecuteInternal(commandContext);
        }

        protected abstract Task ExecuteInternal(ICommandContext commandContext);
    }
}
