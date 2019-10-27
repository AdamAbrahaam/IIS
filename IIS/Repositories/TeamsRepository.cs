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

        public async Task<Statistics[]> GetStatisticsForTeamAsync(int id)
        {

            var query = _context.Statistics
                .Where(t => t.Team.TeamId == id)
                .OrderBy(t => t.Points);
            return await query.ToArrayAsync();
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            var query = _context.Teams.Where(t => t.TeamId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User[]> GetUsersInTeamAsync(int id)
        {
            var query = _context.Users
                .Where(t => t.Team.TeamId == id)
                .OrderBy(t => t.FirstName);
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
