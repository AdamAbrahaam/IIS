﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Data.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; } 
        public int Round { get; set; }
        public string Winner { get; set; }
        public User Home { get; set; }
        public User Away { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<UsersInMatch> UsersInMatches { get; set; } = new List<UsersInMatch>();
        public ICollection<TeamsInMatch> TeamsInMatches { get; set; } = new List<TeamsInMatch>();
    }
}
