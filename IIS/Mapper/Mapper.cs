using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIS.Data.Entities;
using IIS.Models;

namespace IIS.Mapper
{
    public class Mapper : IMapper
    {
        #region User mapping
        public User MapUserToEntity(UserModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new User
            {
                UserID = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            };
        }

        public UserModel MapUserModelFromEntity(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserModel
            {
                UserId = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }
        #endregion
    }
}