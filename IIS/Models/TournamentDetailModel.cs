using IIS.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class TournamentDetailModel
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
        public string Sponsors { get; set; }
        public string Type { get; set; }
        public ICollection<MatchModel> Matches { get; set; }
        public ICollection<StatisticsModel> Statistics { get; set; }
        public ICollection<ParticipantModel> Participants { get; set; }
        public string Organizer { get; set; }
        public string Referee { get; set; }
    }
}
