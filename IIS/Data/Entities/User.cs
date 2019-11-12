using System.Collections.Generic;

namespace IIS.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Password { get; set; }
        public Team Team { get; set; }
        public bool isAdmin { get; set; }
        public ICollection<Statistics> Statistics { get; set; } = new List<Statistics>();
        public ICollection<UsersInMatch> UsersInMatches { get; set; } = new List<UsersInMatch>();
    }
}
