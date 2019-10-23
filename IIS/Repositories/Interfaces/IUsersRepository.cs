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
        Task<User> GetUserByEmailAsync(string email);
    }
}
