using IIS.Data;
using IIS.Data.Entities;
using IIS.Models;
using IIS.Repositories.Interfaces;
using IIS.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories
{
    public class UsersRepository : IUsersRepository 
    {
        private readonly FifkaDBContext _context;
        public UsersRepository(FifkaDBContext context)
        {
            _context = context;
        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            var query = _context.Users;
            return await query.ToArrayAsync();
        }
    }
}
