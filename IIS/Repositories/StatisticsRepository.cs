using IIS.Data;
using IIS.Data.Entities;
using IIS.Models;
using IIS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly FifkaDBContext _context;
        public StatisticsRepository(FifkaDBContext context)
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

        public async Task<Statistics> GetStatisticsById(int id)
        {
            var query = _context.Statistics.Where(t => t.StatisticsId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Statistics[]> GetStatisticsTeamsRanking()
        {
            var query = _context.Statistics.Where(t => t.Team != null && t.Tournament == null)
                .Include(t => t.Team);
            return await query.ToArrayAsync();
        }

        public async Task<Statistics[]> GetStatisticsUsersRanking()
        {
           var query = _context.Statistics.Where(t => t.User != null && t.Tournament == null)
                .Include(t => t.User); 
            return await query.ToArrayAsync();
        }

        public async Task<Team> GetTeamById(int id)
        {
            var query = _context.Teams.Where(t => t.TeamId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Tournament> GetTournamentById(int id)
        {
            var query = _context.Tournaments.Where(t => t.TournamentId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(int id)
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
