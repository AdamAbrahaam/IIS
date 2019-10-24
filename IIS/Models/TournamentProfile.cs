using AutoMapper;
using IIS.Data;
using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Models
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            this.CreateMap<Tournament, TournamentTableModel>()
                .ReverseMap();
            this.CreateMap<Tournament, TournamentDetailModel>()
                .ReverseMap();
            this.CreateMap<User, UserModel>()
                .ReverseMap();
            this.CreateMap<Statistics, StatisticsModel>()
                .ReverseMap();
            this.CreateMap<Team, TeamModel>()
                .ReverseMap();
                
        }

    }

}
