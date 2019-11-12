using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TeamModel Team { get; set; }
        public bool isAdmin { get; set; }
    }
}
