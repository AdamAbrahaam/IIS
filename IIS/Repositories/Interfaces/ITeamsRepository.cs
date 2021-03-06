﻿using IIS.Data;
using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Team> GetTeamByIdAsync(int id);
        Task<Team> GetTeamByNameAsync(string name);
        Task<Team[]> GetAllTeamsAsync();
        Task<User[]> GetUsersInTeamAsync(string name);
        Task<User> GetUserByIdAsync(int id);
        Task<Statistics[]> GetStatisticsForTeamAsync(string name);
        Task<Statistics> GetMainStatisticsAsync(string name);
        Task<Statistics> GetTournamentStatisticsAsync(string name, int id);
    }
}
