using AutoMapper;
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
            this.CreateMap<Tournament, TournamentModel>()
                .ReverseMap();
            this.CreateMap<User, UserModel>()
                .ReverseMap();
        }

    }

}
