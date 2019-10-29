using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Data
{
    public class Statistics
    {
        public int StatisticsId { get; set; }
        public int Goals { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public int Points => Wins * 3 + Draws;
        public User User { get; set; }
        public string Team { get; set; }
        public Tournament Tournament { get; set; }
    }
}
