using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFootball.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string NFLTeam { get; set; }
        public string WeeklyOpponent { get; set; }
        public string Position { get; set; }
        public bool FreeAgent { get; set; }
        public bool Active { get; set; }
        public string InjuryStatus { get; set; }
        public int PassingYards { get; set; }
        public int PassingTD { get; set; }
        public int IntThrown { get; set; }
        public int Receptions { get; set; }
        public int RecievingYards { get; set; }
        public int RecievingTD { get; set; }
        public int RushingYards { get; set; }
        public int RushingTD { get; set; }
        public int TwoPtConv { get;set;}
        public int Fumbles { get; set; }
        public int FgShort { get; set; }
        public int FgMedium { get; set; }
        public int FgLong { get; set; }
        public int PointAfter { get; set; }
        public int PointsAllowed { get; set; }
        public int Interception { get; set; }
        public int Sack { get; set; }
        public int ForcedFumble { get; set; }
        public int FumbleRecovery { get; set; }
        public int BlockedKick { get; set; }
        public int DefTD { get; set; }
        public int Safety { get; set; }

        public virtual Team Team { get; set; }
       
    }
}
