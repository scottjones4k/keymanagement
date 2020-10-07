using KeyManagement.Repository;
using KeyManagement.Repository.Entities;
using KeyManagment.Bus;
using KeyManagment.Bus.Commands;
using System;
using System.Threading.Tasks;

namespace KeyManagement.Logic.Commands
{
    public class CreateKey : BaseCommand
    {
        private CreateKey() { }

        public CreateKeyParams CommandParams { get; private set; }

        public static BaseCommand Create(CreateKeyParams commandParams)
        {
            if (commandParams == null)
            {
                throw new ArgumentNullException(nameof(commandParams));
            }

            return new CreateKey
            {
                CommandParams = commandParams
            };
        }

        protected override async Task ExecuteInternal(ICommandContext commandContext)
        {
            var context = ((BusContext)commandContext).DataContext;
            await context.AddAsync(new Key
            {
                Id = CommandParams.Id,
                KeySetId = CommandParams.KeySetId,
                KeyType = CommandParams.KeyType
            });
            await context.SaveChangesAsync();
        }
    }
}
