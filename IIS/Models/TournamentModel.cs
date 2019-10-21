﻿using IIS.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class TournamentModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; } = DateTime.MinValue;
        public int Prize { get; set; }
        public int Entry { get; set; }
        public int Capacity { get; set; }
        public StringCollection Sponsors { get; set; }
        public TournamentType Type { get; set; }
        public ObservableCollection<MatchModel> Matches { get; set; }
        public MatchModel NewMatch { get; set; }
        public UserModel Organizer { get; set; }
    }
}
