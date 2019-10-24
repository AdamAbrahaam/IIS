using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Data.Entities
{
    public class UsersInMatch
    {
        public int UsersInMatchId { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
