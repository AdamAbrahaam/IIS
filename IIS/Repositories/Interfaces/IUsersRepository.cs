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
        void Add<T>(T entity) where T : class;

        Task<User[]> GetAllUsersAsync();
    }
}
