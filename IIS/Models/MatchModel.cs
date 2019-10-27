using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class MatchModel
    {
        public DateTime Date { get; set; } = DateTime.MinValue;
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public User Referee { get; set; }
        public Tournament Tournament { get; set; }
    }
}
