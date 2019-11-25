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

        public void Add(User user)
        {
            var passwordHasher = new PasswordHasher(user.Password);
            user.Password = passwordHasher.GetHashedPassword();

            _context.Add(user);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = _context.Users.Where(t => t.UserId == id).Include( t => t.Team);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var query = _context.Users.Where(t => t.Email == email).Include( t => t.Team);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User[]> GetAllUsers()
        {
            var query = _context.Users;
            return await query.ToArrayAsync();
        }

        public async Task<Statistics> GetMainStatisticsAsync(int id)
        {
            var query = _context.Statistics.Where(t => t.User.UserId == id && t.Tournament == null);
            return await query.FirstOrDefaultAsync();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<Statistics> GetStatisticsInTournament(int userid, int tournamentid)
        {
            var query = _context.Statistics.Where(t => t.Tournament.TournamentId == tournamentid && t.User.UserId == userid);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Team> GetTeamByIdAsync(string name)
        {
            var query = _context.Teams.Where(t => t.Name == name).Include(t => t.Users);
            return await query.FirstOrDefaultAsync();
        }
    }
}
