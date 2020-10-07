using KeyManagement.Repository;
using KeyManagement.Repository.Entities;
using KeyManagment.Bus;
using KeyManagment.Bus.Commands;
using System;
using System.Threading.Tasks;

namespace KeyManagement.Logic.Commands
{
    public class CreateKeySet : BaseCommand
    {
        private CreateKeySet() { }

        public CreateKeySetParams CommandParams { get; private set; }

        public static BaseCommand Create(CreateKeySetParams commandParams)
        {
            if (commandParams == null)
            {
                throw new ArgumentNullException(nameof(commandParams));
            }

            return new CreateKeySet
            {
                CommandParams = commandParams
            };
        }

        protected override async Task ExecuteInternal(ICommandContext commandContext)
        {
            var context = ((BusContext)commandContext).DataContext;
            await context.AddAsync(new KeySet
            {
                Id = CommandParams.Id
            });
            await context.SaveChangesAsync();
        }
    }
}
