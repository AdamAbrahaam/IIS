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
        public string Date { get; set; }
        public string Time { get; set; }
        public string Info { get; set; }
        public int Prize { get; set; }
        public int Entry { get; set; }
        public int Capacity { get; set; }
        public User Organizer { get; set; }
        public User Referee { get; set; }
        public string Sponsors { get; set; }
        public string Type { get; set; }
        public ICollection<Statistics> Statistics { get; set; }
        public ICollection<Match> Matches { get; set; } = new List<Match>();
        public string[] Participants { get; set; }
    }
}
