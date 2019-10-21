using IIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        UserModel Create(UserModel user);
        UserModel GetById(Guid id);
        UserModel GetByEmail(string email);
    }
}
