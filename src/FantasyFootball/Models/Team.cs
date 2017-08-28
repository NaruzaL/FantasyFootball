using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFootball.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TotalPoints { get; set; }
        public int WeekPoints { get; set; }
        public int MaxPlayers { get; set; }
        public int CurrentPlayers { get; set; }
        public int LeagueId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual League League { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public Team()
        {
            TotalPoints = 0;
            WeekPoints = 0;
        }
    }
}
