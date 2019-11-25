using IIS.Data;
using IIS.Data.Entities;
using IIS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly FifkaDBContext _context;
        public TeamsRepository(FifkaDBContext context)
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

        public async Task<Team[]> GetAllTeamsAsync()
        {
            var query = _context.Teams;
            return await query.ToArrayAsync();
        }

        public async Task<Statistics> GetMainStatisticsAsync(string name)
        {
            var query = _context.Statistics.Where(t => t.Team == name && t.Tournament == null);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Statistics[]> GetStatisticsForTeamAsync(string name)
        {

            var query = _context.Statistics
                .Where(t => t.Team == name);
            return await query.ToArrayAsync();
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            var query = _context.Teams.Where(t => t.TeamId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Team> GetTeamByNameAsync(string name)
        {
            var query = _context.Teams.Where(t => t.Name == name).Include(t => t.Users)
                .Include(t => t.TeamsInMatches);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Statistics> GetTournamentStatisticsAsync(string name, int id)
        {
            var query = _context.Statistics.Where(t => t.Team == name && t.Tournament.TournamentId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var query = _context.Users.Where(t => t.UserId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User[]> GetUsersInTeamAsync(string name)
        {
            var query = _context.Users
                .Where(t => t.Team.Name == name)
                .OrderBy(t => t.FirstName);
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
