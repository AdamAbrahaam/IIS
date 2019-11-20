using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class MatchModel
    {
        public int MatchId { get; set; }
        public string Winner { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int Round { get; set; }
        public UserNameModel Home { get; set; }
        public UserNameModel Away { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public TournamentNameModel Tournament { get; set; }
    }
}
