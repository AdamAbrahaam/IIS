using System.Collections.Generic;

namespace IIS.Data.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public ICollection<TeamsInMatch> TeamsInMatches { get; set; } = new List<TeamsInMatch>();
        public ICollection<TeamsInTournament> TeamsInTournaments { get; set; } = new List<TeamsInTournament>();
        public ICollection<Statistics> Statistics { get; set; } = new List<Statistics>();
    }
}
