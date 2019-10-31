using AutoMapper;
using IIS.Data.Entities;
using IIS.Models;
using IIS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentsRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public TournamentsController(ITournamentsRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<TournamentTableModel[]>> Get() {
            try
            {
                var result = await _repository.GetAllTournamentsAsync();

                return _mapper.Map<TournamentTableModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TournamentDetailModel>> Get(int id)
        {
            try
            {
                var result = await _repository.GetTournamentById(id);

                return _mapper.Map<TournamentDetailModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("stats-for-users{id:int}")]
        public async Task<ActionResult<StatisticsModel[]>> GetUsersStats(int id)
        {
            try
            {
                var result = await _repository.GetStatisticsSoloAsync(id);
                return _mapper.Map<StatisticsModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("stats-for-teams{id:int}")]
        public async Task<ActionResult<StatisticsModel[]>> GetTeamsStats(int id)
        {
            try
            {
                var result = await _repository.GetStatisticsTeamsAsync(id);
                return _mapper.Map<StatisticsModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpPost("add-tournament")]
        public async Task<ActionResult<TournamentDetailModel[]>> Post(TournamentDetailModel model)
        {
            try
            {
                var location = _linkGenerator.GetPathByAction(
                    "Get",
                    "Tournaments",
                    new { name = model.Name });
                var tournament = _mapper.Map<Tournament>(model);
                _repository.Add(tournament);
                if (await _repository.SaveChangesAsync())
                {
                    return Created(location, _mapper.Map<TournamentDetailModel>(tournament));
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
                var tournament = await _repository.GetTournamentById(id);
                _repository.Delete(tournament);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest("Failed to delete tournament");
        }

        [HttpPut("add-user")]
        public async Task<IActionResult> AddUser(int userid, int tournamentid)
        {
            try
            {
                var tournament = await _repository.GetTournamentById(tournamentid);
                if (tournament == null) return NotFound("Tournament not found!");
                var user = await _repository.GetUserById(userid);
                if (user == null) return NotFound("User not foun!");
                if (tournament.Participants == null)
                    tournament.Participants = new string[] { user.FullName };
                else
                {
                    var participants = tournament.Participants.ToList();
                    if (participants.Contains(user.FullName)) return StatusCode(StatusCodes.Status409Conflict, "User already in tournament!");
                    participants.Add(user.FullName);
                    tournament.Participants = participants.ToArray();
                }
                if (await _repository.SaveChangesAsync())
                {
                    var location = _linkGenerator.GetPathByAction(
                        "Get",
                        "Tournaments",
                        new { id = tournament.TournamentId });
                    return Created(location, _mapper.Map<TournamentDetailModel>(tournament));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest("Failed to delete tournament");
        }

        [HttpPut("add-team")]
        public async Task<IActionResult> AddTeam(int teamid, int tournamentid)
        {
            try
            {
                var tournament = await _repository.GetTournamentById(tournamentid);
                if (tournament == null) return NotFound("Tournament not found!");
                var team = await _repository.GetTeamById(teamid);
                if (team == null) return NotFound("Team not foun!");
                if (tournament.Participants == null)
                    tournament.Participants = new string[] { team.Name };
                else
                {
                    var participants = tournament.Participants.ToList();
                    if (participants.Contains(team.Name)) return StatusCode(StatusCodes.Status409Conflict, "Team already in tournament!");
                    participants.Add(team.Name);
                    tournament.Participants = participants.ToArray();
                }
                if (await _repository.SaveChangesAsync())
                {
                    var location = _linkGenerator.GetPathByAction(
                        "Get",
                        "Tournaments",
                        new { id = tournament.TournamentId });
                    return Created(location, _mapper.Map<TournamentDetailModel>(tournament));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest("Failed to delete tournament");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TournamentDetailModel>> Put(int id, TournamentDetailModel model)
        {
            try
            {
                var oldTournament = await _repository.GetTournamentById(id);
                if (oldTournament == null) return NotFound("Tournament does not exists!");
                _mapper.Map(model, oldTournament);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<TournamentDetailModel>(oldTournament);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest();
        }
    }
}
