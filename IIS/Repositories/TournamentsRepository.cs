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
        public async Task<Tournament[]> GetAllTournamentsAsync()
        {
            var query = _context.Tournaments.OrderBy(t => t.Date);

            return await query.ToArrayAsync();
        }
    }
}
