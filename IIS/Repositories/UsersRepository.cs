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

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Statistics[]> GetStatistics(int id)
        {
            IQueryable<Statistics> query = _context.Statistics
                .Where(t => t.User.UserId == id);
            return await query.ToArrayAsync(); 
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var query = _context.Users.Where(t => t.Email == email);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = _context.Users.Where(t => t.UserId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
