﻿using IIS.Data;
using IIS.Data.Entities;
using IIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        void Add(User user);
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User[]> GetAllUsers();
        Task<Statistics> GetStatisticsInTournament(int userid, int tournamentid);
        Task<Statistics> GetMainStatisticsAsync(int id);
        Task<Team> GetTeamByIdAsync(string name);
    }
}
