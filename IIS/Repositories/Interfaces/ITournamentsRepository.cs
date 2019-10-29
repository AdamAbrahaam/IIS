using IIS.Data;
using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories.Interfaces
{
    public interface ITournamentsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Tournament[]> GetAllTournamentsAsync();
        Task<Tournament> GetTournamentById(int id);
        Task<Statistics[]> GetStatisticsSoloAsync(int id);
        Task<Statistics[]> GetStatisticsTeamsAsync(int id);
        Task<User> GetUserById(int id);
    }
}
