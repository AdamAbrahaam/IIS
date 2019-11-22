using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IIS.Data;
using IIS.Data.Entities;
using IIS.Models;
using IIS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace IIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : Controller
    {
        private readonly IMatchesRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public MatchesController(IMatchesRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MatchModel>> GetMatch(int id)
        {
            try
            {
                var match = await _repository.GetMatchById(id);
                if (match == null) return NotFound("Match not found!");
                return _mapper.Map<MatchModel>(match);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("solo_match{id:int}")]
        public async Task<ActionResult<MatchModel>> GetSoloMatch(int id)
        {
            try
            {
                var match = await _repository.GetSoloMatchById(id);
                if (match == null) return NotFound("Match not found!");
                return _mapper.Map<MatchModel>(match);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("duo_match{id:int}")]
        public async Task<ActionResult<MatchModel>> GetDuoMatch(int id)
        {
            try
            {
                var match = await _repository.GetDuoMatchById(id);
                if (match == null) return NotFound("Match not found!");
                return _mapper.Map<MatchModel>(match);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("tournament/{id:int}")]
        public async Task<ActionResult<MatchModel[]>> Get(int id)
        {
            try
            {
                Match[] matches;
                var tournament = await _repository.GetTournamentById(id);
                if (tournament == null) return NotFound("Tournament not found!");
                if (tournament.Type == "duo")
                    matches = await _repository.GetAllDuoMatchesInTournament(id);
                else
                    matches = await _repository.GetAllSoloMatchesInTournament(id);
                return _mapper.Map<MatchModel[]>(matches);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpPost("solo_match")]
        public async Task<ActionResult<MatchModel>> PostSolo(int userid1, int userid2, int tournamentid, int round)
        {
            try
            {
                var tournament = await _repository.GetTournamentById(tournamentid);
                if (tournament == null) return NotFound("Tournament not found!");

                var homeUser = await _repository.GetUserById(userid1);
                var awayUser = await _repository.GetUserById(userid2);
                if (homeUser == null || awayUser == null) return NotFound("User not foun!");
                var match = new Match()
                {
                    Tournament = _mapper.Map<Tournament>(tournament),
                    Home = _mapper.Map<User>(homeUser),
                    Away = _mapper.Map<User>(awayUser),
                    Round = round
                };
                _repository.Add(match);

                if (await _repository.SaveChangesAsync())
                {
                    var uimEntity = new UsersInMatch()
                    {
                        Home = true,
                        User = homeUser,
                        Match = match
                    };
                    var uimEntity2 = new UsersInMatch()
                    {
                        Home = false,
                        User = awayUser,
                        Match = match
                    };
                    _repository.AddUser(uimEntity, match.MatchId);
                    _repository.AddUser(uimEntity2, match.MatchId);
                    var location = _linkGenerator.GetPathByAction(HttpContext,
                       "GetSoloMatch",
                        values: new { id =  match.MatchId});
                    return Created(location, _mapper.Map<MatchModel>(match));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest();
        }

        [HttpPost("duo_match")]
        public async Task<ActionResult<MatchModel>> PostDuo(int teamid1, int teamid2, int tournamentid)
        {
            try
            {
                var tournament = await _repository.GetTournamentById(tournamentid);
                if (tournament == null) return NotFound("Tournament not found!");
                var homeTeam = await _repository.GetTeamById(teamid1);
                var awayTeam = await _repository.GetTeamById(teamid2);
                if (homeTeam == null || awayTeam == null) return NotFound("Team not found!");
                var match = new Match()
                {
                    Tournament = _mapper.Map<Tournament>(tournament),
                    HomeTeam = homeTeam.Name,
                    AwayTeam = homeTeam.Name
                };
                _repository.Add(match);
                if (await _repository.SaveChangesAsync())
                {
                    var uimEntity = new TeamsInMatch()
                    {
                        Home = true,
                        Team = homeTeam,
                        Match = match
                    };
                    var uimEntity2 = new TeamsInMatch()
                    {
                        Home = false,
                        Team = awayTeam,
                        Match = match
                    };
                    _repository.AddTeam(uimEntity, match.MatchId);
                    _repository.AddTeam(uimEntity2, match.MatchId);
                    var location = _linkGenerator.GetPathByAction(HttpContext,
                       "GetDuoMatch",
                        values: new {id = match.MatchId });
                    return Created(location, _mapper.Map<MatchModel>(match));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MatchModel>> Put(int id, MatchModel model)
        {
            try
            {
                var oldMatch = await _repository.GetMatchById(id);
                if (oldMatch == null) return NotFound("Does not exists!");
                _mapper.Map(model, oldMatch);
                int homeScore = oldMatch.HomeScore;
                int awayScore = oldMatch.AwayScore;
                Statistics homeStatsOverall;
                Statistics awayStatsOverall;
                Statistics homeStats;
                Statistics awayStats;

                if (oldMatch.HomeTeam == null)
                {
                    homeStatsOverall = await _repository.GetOverallStats(oldMatch.Home.UserId);
                    awayStatsOverall = await _repository.GetOverallStats(oldMatch.Away.UserId);
                    homeStats = await _repository.GetTournamentStats(oldMatch.Home.UserId, oldMatch.Tournament.TournamentId);
                    awayStats = await _repository.GetTournamentStats(oldMatch.Away.UserId, oldMatch.Tournament.TournamentId);
                }
                else
                {
                    homeStatsOverall = await _repository.GetOverallTeamStats(oldMatch.HomeTeam);
                    awayStatsOverall = await _repository.GetOverallTeamStats(oldMatch.AwayTeam);
                    homeStats = await _repository.GetTournamentTeamStats(oldMatch.HomeTeam, oldMatch.Tournament.TournamentId);
                    awayStats = await _repository.GetTournamentTeamStats(oldMatch.AwayTeam, oldMatch.Tournament.TournamentId);
                }

                homeStatsOverall.Goals += homeScore;
                homeStatsOverall.Games += 1;
                homeStats.Goals += homeScore;
                homeStats.Games += homeScore;
                awayStatsOverall.Goals += awayScore;
                awayStatsOverall.Games += 1;
                awayStats.Goals += awayScore;
                awayStats.Games += awayScore;

                if (homeScore > awayScore)
                {
                    homeStatsOverall.Wins += 1;
                    homeStats.Wins += 1;
                    awayStatsOverall.Loses += 1;
                    awayStats.Loses += 1;
                }
                else if (homeScore < awayScore)
                {
                    homeStatsOverall.Loses += 1;
                    homeStats.Loses += 1;
                    awayStatsOverall.Wins += 1;
                    awayStats.Wins += 1;
                }
                else
                {
                    homeStatsOverall.Draws += 1;
                    homeStats.Draws += 1;
                    awayStatsOverall.Draws += 1;
                    awayStats.Draws += 1;
                }

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<MatchModel>(oldMatch);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var match = await _repository.GetMatchById(id);
                if (match == null) return NotFound("Match not found!");
                _repository.Delete(match);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest("Failed to delete team!");
        }
    }
}
