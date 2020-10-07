using KeyManagement.Repository.Entities;

namespace KeyManagement.Logic.Commands
{
    public class CreateKeyParams
    {
        public string KeySetId { get; set; }
        public KeyType KeyType { get; set; }
        public string Id { get; set; }
    }
}
