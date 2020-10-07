using KeyManagment.Bus.Commands;
using System.Threading.Tasks;

namespace KeyManagment.Bus
{
    public interface ICommandBus
    {
        Task ExecuteCommand(params BaseCommand[] commands);
    }
}