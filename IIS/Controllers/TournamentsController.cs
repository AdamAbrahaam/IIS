﻿using AutoMapper;
using IIS.Data;
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
                if (result == null) return NotFound("No tournament found!");
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
                if (result == null) return NotFound("Tournament not found!");
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
                if (result == null) return NotFound("No statistics found!");
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
                if (result == null) return NotFound("No statistics found!");
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

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tournament = await _repository.GetTournamentById(id);
                if (tournament == null) return NotFound("No tournament found!");
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
                if (user == null) return NotFound("User not found!");
                var participant = new Participant
                {
                    Name = user.FullName,
                    UserOrTeam = user.UserId,
                    IsUser = true
                };
                if (tournament.Participants.Any(t => t.Name == participant.Name))
                    return StatusCode(StatusCodes.Status409Conflict, "User already in tournament");
                _repository.Add(participant);
                tournament.Participants.Add(participant);
                if (await _repository.SaveChangesAsync())
                {
                    var stats = new Statistics
                    {
                        Goals = 0,
                        Games = 0,
                        Wins = 0,
                        Draws = 0,
                        Loses = 0,
                        User = user,
                        Tournament = tournament
                    };
                    _repository.Add(stats);
                    await _repository.SaveChangesAsync();
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
            return BadRequest("Failed to add user to tournament!");
        }

        [HttpPut("add-team")]
        public async Task<IActionResult> AddTeam(int teamid, int tournamentid)
        {
            try
            {
                var tournament = await _repository.GetTournamentById(tournamentid);
                if (tournament == null) return NotFound("Tournament not found!");
                var team = await _repository.GetTeamById(teamid);
                if (team == null) return NotFound("Team not found!");
                var participant = new Participant
                {
                    Name = team.Name,
                    UserOrTeam = team.TeamId,
                    IsUser = false
                };
                if (tournament.Participants.Any(t => t.Name == participant.Name))
                    return StatusCode(StatusCodes.Status409Conflict, "Team already in tournament");
                _repository.Add(participant);
                tournament.Participants.Add(participant);
                if (await _repository.SaveChangesAsync())
                {
                    var stats = new Statistics
                    {
                        Goals = 0,
                        Games = 0,
                        Wins = 0,
                        Draws = 0,
                        Loses = 0,
                        Team = team.Name,
                        Tournament = tournament
                    };
                    _repository.Add(stats);
                    await _repository.SaveChangesAsync();
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
            return BadRequest("Failed to add team to tournament!");
        }

        [HttpPut("add-referee")]
        public async Task<IActionResult> AddReferee(int userid, int tournamentid)
        {
            try
            {
                var tournament = await _repository.GetTournamentById(tournamentid);
                if (tournament == null) return NotFound("Tournament not found!");
                var user = await _repository.GetUserById(userid);
                if (user == null) return NotFound("User not found!");
                tournament.Referee = user.FullName;
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
            return BadRequest("Failed to add team to tournament!");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TournamentDetailModel>> Put(int id, TournamentDetailModel model)
      {
            try
            {
                var oldTournament = await _repository.GetTournamentById(id);
                if (oldTournament == null) return NotFound("Tournament does not exists!");
                oldTournament.Location = model.Location;
                oldTournament.Prize = model.Prize;
                oldTournament.Entry = model.Entry;
                oldTournament.Capacity = model.Capacity;
                oldTournament.Type = model.Type;
                oldTournament.Organizer = model.Organizer;
                oldTournament.Referee = model.Referee;
                oldTournament.Sponsors = model.Sponsors;
                oldTournament.Info = model.Info;
                oldTournament.Date = model.Date;
                oldTournament.Time = model.Time;
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
