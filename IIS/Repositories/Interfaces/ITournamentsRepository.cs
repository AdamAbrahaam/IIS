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
        Task<Tournament[]> GetAllTournamentsAsync();
        Task<Tournament[]> GetTournamentByDate();
        Task<Tournament> GetTournamentById(int id);
    }
}
