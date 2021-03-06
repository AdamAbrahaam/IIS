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
    public class MatchesRepository : IMatchesRepository
    {
        private readonly FifkaDBContext _context;

        public MatchesRepository(FifkaDBContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void AddTeam(TeamsInMatch entity, int id)
        {
            _context.Matches.First(t => t.MatchId == id)
                .TeamsInMatches
                .Add(entity);
            _context.TeamsInMatches.Update(entity);
            _context.SaveChanges();
        }

        public void AddUser(UsersInMatch entity, int id)
        {
            _context.Matches.First(t => t.MatchId == id)
                .UsersInMatches
                .Add(entity);
            _context.UsersInMatches.Update(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Match[]> GetAllDuoMatchesInTournament(int id)
        {
            var query = _context.Matches.Include(t => t.Tournament)
                .Where(t => t.Tournament.TournamentId == id);
            return await query.ToArrayAsync();
        }

        public async Task<Match[]> GetAllSoloMatchesInTournament(int id)
        {
            var query = _context.Matches.Include(t=>t.Tournament)
                .Where(t => t.Tournament.TournamentId == id)
                .Include(t => t.Home)
                .Include(t => t.Away);
            return await query.ToArrayAsync();
        }

        public async Task<Match> GetDuoMatchById(int id)
        {
            var query = _context.Matches.Where(t => t.MatchId == id)
                .Include(t => t.Tournament);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Match> GetMatchById(int id)
        {
            var query = _context.Matches.Where(t => t.MatchId == id)
                .Include(t => t.Tournament).Include(t => t.Home).Include(t => t.Away);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Statistics> GetOverallStats(int userId)
        {
            var query = _context.Statistics.Where(t => t.User.UserId == userId && t.Tournament == null);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Statistics> GetOverallTeamStats(string team)
        {
            var query = _context.Statistics.Where(t => t.Team == team && t.Tournament == null);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Match> GetSoloMatchById(int id)
        {
            var query = _context.Matches.Where(t => t.MatchId == id)
                .Include(t => t.Home)
                .Include(t => t.Away)
                .Include(t => t.Tournament);
            return await query.FirstOrDefaultAsync();
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

        public async Task<Statistics> GetTournamentStats(int userId, int tournamentId)
        {
            var query = _context.Statistics.Where(t => t.User.UserId == userId && t.Tournament.TournamentId == tournamentId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Statistics> GetTournamentTeamStats(string team, int tournamentId)
        {
            var query = _context.Statistics.Where(t => t.Team == team && t.Tournament.TournamentId == tournamentId);
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
