using System.ComponentModel.DataAnnotations;

namespace KeyManagement.Repository.Entities
{
    public class Key
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string KeySetId { get; set; }

        public KeyType KeyType { get; set; }

        public string AssignedTo { get; set; }
    }
}
