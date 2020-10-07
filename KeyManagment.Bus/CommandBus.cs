using KeyManagment.Bus.Commands;
using System.Threading.Tasks;

namespace KeyManagment.Bus
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandContext _commandContext;

        public CommandBus(ICommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public async Task ExecuteCommand(params BaseCommand[] commands)
        {
            foreach (var command in commands)
            {
                await command.Execute(_commandContext);
            }
        }
    }
}
