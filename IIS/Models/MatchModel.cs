using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class MatchModel
    {
        public int MatchID { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime Date { get; set; } = DateTime.MinValue;
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public StatisticsModel Statistics { get; set; }
        public UserModel Referee { get; set; }
    }
}
