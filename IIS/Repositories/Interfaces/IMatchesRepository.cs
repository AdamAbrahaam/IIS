using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories.Interfaces
{
    public interface IMatchesRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void AddUser(UsersInMatch entity, int id);
        void AddTeam(TeamsInMatch entity, int id);
        Task<bool> SaveChangesAsync();
        Task<Match> GetMatchById(int id);
        Task<Match> GetSoloMatchById(int id);
        Task<Match> GetDuoMatchById(int id);
        Task<Match[]> GetAllSoloMatchesInTournament(int id);
        Task<Match[]> GetAllDuoMatchesInTournament(int id);
        Task<Tournament> GetTournamentById(int id);
        Task<User> GetUserById(int id);
        Task<Team> GetTeamById(int id);
    }
}
