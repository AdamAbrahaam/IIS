using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace IIS.Data.Entities
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; } = DateTime.MinValue;
        public int Prize { get; set; }
        public int Entry { get; set; }
        public int Capacity { get; set; }
        public User Organizer { get; set; }
        public string[] Sponsors { get; set; }
        public TournamentType Type { get; set; }
        public ICollection<Statistics> Statistics { get; set; }
        public ICollection<Match> Matches { get; set; } = new List<Match>();
        public ICollection<TeamsInTournament> TeamsInTournaments { get; set; } = new List<TeamsInTournament>();
        public ICollection<UsersInTournament> UsersInTournaments { get; set; } = new List<UsersInTournament>();
    }
}
