﻿using IIS.Data;
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

        public void Delete(Tournament tournament)
        {
            var query = _context.Tournaments.Include(t => t.Matches)
                .Include(t => t.Statistics)
                .First(t => t.TournamentId == tournament.TournamentId);
            _context.Remove(query);
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

        public async Task<Team> GetTeamById(int id)
        {
            var query = _context.Teams.Where(t => t.TeamId == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Tournament> GetTournamentById(int id)
        {
            var query = _context.Tournaments.Where(t => t.TournamentId == id)
                .Include(t => t.Participants);
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
