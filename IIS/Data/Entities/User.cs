using System.Collections.Generic;

namespace IIS.Data.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Statistics> Statistics { get; set; } = new List<Statistics>();
        public ICollection<UsersInMatch> UsersInMatches { get; set; } = new List<UsersInMatch>();

    }
}
