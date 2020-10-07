using System.ComponentModel.DataAnnotations;

namespace KeyManagement.Repository.Entities
{
    public class KeySet
    {
        [MaxLength(50)]
        public string Id { get; set; }
    }
}
