using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class TeamModel : BaseModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
    }
}
