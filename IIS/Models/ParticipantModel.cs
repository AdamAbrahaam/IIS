using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class ParticipantModel
    {
        public int ParticipantId { get; set; }
        public string Name { get; set; }
        public int UserOrTeam { get; set; }
        public bool IsUser { get; set; }
    }
}
