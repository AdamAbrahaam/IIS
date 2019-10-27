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
    public class TournamentsRepository : ITournamentsRepository
    {
        private readonly FifkaDBContext _context;

        public TournamentsRepository(FifkaDBContext context)
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

        public async Task<Tournament[]> GetAllTournamentsAsync()
        {
            var query = _context.Tournaments.OrderBy(t => t.Date);

            return await query.ToArrayAsync();
        }

        public async Task<Statistics[]> GetStatisticsSoloAsync(int id)
        {
            var query = _context.Statistics.Where(t => t.Tournament.TournamentId == id && t.User != null)
                .Include(t => t.User);
            return await query.ToArrayAsync();
        }

        public async Task<Statistics[]> GetStatisticsTeamsAsync(int id)
        {
            var query = _context.Statistics.Where(t => t.Tournament.TournamentId == id && t.Team != null)
                .Include(t => t.Team);
            return await query.ToArrayAsync();
        }

        public async Task<Tournament> GetTournamentById(int id)
        {
            var query = _context.Tournaments.Where(t => t.TournamentId == id)
                .Include(t => t.Organizer);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
