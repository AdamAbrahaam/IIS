using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Data.Entities
{
    public class TeamsInTournament
    {
        public int TeamsInTournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public Team Team { get; set; }
    }
}
