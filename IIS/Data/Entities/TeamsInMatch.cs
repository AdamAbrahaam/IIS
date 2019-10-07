using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Data.Entities
{
    public class TeamsInMatch
    {
        public int TeamsInMatchId { get; set; }
        public Team Team { get; set; }
        public Match Match { get; set; }
    }
}
