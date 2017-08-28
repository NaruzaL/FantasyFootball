using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFootball.Models
{
    [Table("Responses")]
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        public string Body { get; set; }
        public string DateTime { get; set; }
        public virtual Message Message { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
