using IIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories.Interfaces
{
    public interface ITournamentsRepository
    {
        Task<Tournament[]> GetAllTournamentsAsync();
    }
}
