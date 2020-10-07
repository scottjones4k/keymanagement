using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KeyManagement.Repository.Entities
{
    public class KeyEvent
    {
        [MaxLength(50)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string KeyId { get; set; }

        [MaxLength(50)]
        public string KeySetId { get; set; }

        public KeyEventType KeyEventType { get; set; }

        public string UserId { get; set; }
        public string Assignee { get; set; }
    }
}
