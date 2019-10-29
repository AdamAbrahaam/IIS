using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class MatchModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public Tournament Tournament { get; set; }
    }
}
