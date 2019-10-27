using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Data.Entities
{
    public class UsersInTournament
    {
        public int UsersInTournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public User User { get; set; }
    }
}
