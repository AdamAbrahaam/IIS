using IIS.Data.Entities;
using IIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Mapper
{
    public interface IMapper
    {
        User MapUserToEntity(UserModel model);
        UserModel MapUserModelFromEntity(User entity);
    }
}
