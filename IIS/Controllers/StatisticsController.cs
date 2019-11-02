using AutoMapper;
using IIS.Data;
using IIS.Data.Entities;
using IIS.Models;
using IIS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public StatisticsController(IStatisticsRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StatisticsModel>> Get(int id)
        {
            try
            {
                var result = await _repository.GetStatisticsById(id);
                if (result == null) return NotFound("Statistics not found!");
                return _mapper.Map<StatisticsModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("users_ranking")]
        public async Task<ActionResult<StatisticsModel[]>> GetUsersRanking()
        {
            try
            {
                var result = await _repository.GetStatisticsUsersRanking();
                return _mapper.Map<StatisticsModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("teams_ranking")]
        public async Task<ActionResult<StatisticsModel[]>> GetTeamsRanking()
        {
            try
            {
                var result = await _repository.GetStatisticsTeamsRanking();
                return _mapper.Map<StatisticsModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpPost("add_to_user{id:int}")]
        public async Task<ActionResult<StatisticsModel>> PostStatToUser(int id, StatisticsModel model)
        {
            try
            {
                var user = await _repository.GetUserById(id);
                if (user == null) return NotFound("User not found!");
                var statistics = _mapper.Map<Statistics>(model);
                statistics.User = _mapper.Map<User>(user);
                if(model.Tournament != null)
                {
                    var tournament = await _repository.GetTournamentById(model.Tournament.TournamentId);
                    if (tournament == null) return NotFound("Tournament not found!");
                    statistics.Tournament = _mapper.Map<Tournament>(tournament);
                }
                _repository.Add(statistics);
                if (await _repository.SaveChangesAsync())
                {
                    var location = _linkGenerator.GetPathByAction(HttpContext,
                        "Get",
                        values:new { id = statistics.StatisticsId });
                    return Created(location, _mapper.Map<StatisticsModel>(statistics));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest();
        }

        [HttpPost("add_to_team{id:int}")]
        public async Task<ActionResult<StatisticsModel>> PostStatToTeam(int id, StatisticsModel model)
        {
            try
            {
                var team = await _repository.GetTeamById(id);
                if (team == null) return NotFound("Team not found!");
                var statistics = _mapper.Map<Statistics>(model);
                statistics.Team = team.Name;
                if (model.Tournament != null)
                {
                    var tournament = await _repository.GetTournamentById(model.Tournament.TournamentId);
                    if (tournament == null) return NotFound("Tournament not found!");
                    statistics.Tournament = _mapper.Map<Tournament>(tournament);
                }
                _repository.Add(statistics);
                if (await _repository.SaveChangesAsync())
                {
                    var location = _linkGenerator.GetPathByAction(HttpContext,
                        "Get",
                        values: new { id = statistics.StatisticsId });
                    return Created(location, _mapper.Map<StatisticsModel>(statistics));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<StatisticsModel>> Put(int id, StatisticsModel model)
        {
            try
            {
                var oldStat = await _repository.GetStatisticsById(id);
                if (oldStat == null) return NotFound("Does not exists!");
                _mapper.Map(model, oldStat);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<StatisticsModel>(oldStat);
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
