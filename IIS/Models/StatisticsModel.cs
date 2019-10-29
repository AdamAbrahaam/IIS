using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class StatisticsModel
    {
        public int Goals { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public int Points { get; set; }
        public TournamentNameModel Tournament { get; set; }
        public string Team { get; set; }
        public UserNameModel User { get; set; }
    }
}
