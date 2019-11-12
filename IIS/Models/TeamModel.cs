using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class TeamModel
    {
        public string Name { get; set; }
        public int Logo { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}
