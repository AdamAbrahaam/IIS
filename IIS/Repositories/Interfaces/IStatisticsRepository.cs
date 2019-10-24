using IIS.Data;
using IIS.Data.Entities;
using System.Threading.Tasks;

namespace IIS.Repositories.Interfaces
{
    public interface IStatisticsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Statistics[]> GetStatisticsForUser(int id);
        Task<Statistics[]> GetStatisticsUserRanking();
        Task<Statistics[]> GetStatisticsTeamRanking();
        Task<Statistics> GetStatisticsForTeam(int id);
        Task<Statistics> GetStatisticsById(int id);
        Task<User> GetUserById(int id);
        Task<Team> GetTeamById(int id);

    }
}
