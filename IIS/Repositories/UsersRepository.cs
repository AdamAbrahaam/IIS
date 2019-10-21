using IIS.Factories;
using IIS.Mapper;
using IIS.Models;
using IIS.Repositories.Interfaces;
using IIS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContextFactory _fifkaDbContext;
        private readonly IMapper _mapper;
        public UsersRepository(IDbContextFactory fifkaDbContext, IMapper mapper)
        {
            this._fifkaDbContext = fifkaDbContext;
            this._mapper = mapper;
        }
        public UserModel Create(UserModel user)
        {
            using (var dbContext = _fifkaDbContext.CreateDbContext())
            {
                var passwordHasher = new PasswordHasher(user.Password);
                user.Password = passwordHasher.GetHashedPassword();

                var entity = _mapper.MapUserToEntity(user);
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                return _mapper.MapUserModelFromEntity(entity);
            }
        }

        public UserModel GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
