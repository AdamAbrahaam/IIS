using IIS.Data;
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
        Task<Team[]> GetAllTeamsAsync();
        Task<User[]> GetUsersInTeamAsync(int id);
        Task<Statistics[]> GetStatisticsForTeamAsync(int id);
    }
}
