using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFootball.Models
{
    [Table("Messages")]
    public class Message
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int LeagueId { get; set; }
        public DateTime MessageDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}
