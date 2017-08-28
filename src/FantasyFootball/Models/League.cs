using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFootball.Models
{
    [Table("Leagues")]
    public class League
    {
      [Key]
      public int LeagueId { get; set; }
      public string Name { get; set; }
      public int MaxTeams { get; set; }
      public int TeamCount { get; set; }
      public virtual ICollection<Message> Messages { get; set; }
      public virtual ApplicationUser User { get; set; }
      public virtual ICollection<Team> Teams { get; set; }
      
        public League ()
        {
            TeamCount = 0;
            MaxTeams = 10;
        }
    
     }
}
