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
    public class TeamsController : Controller
    {
        private readonly ITeamsRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public TeamsController(ITeamsRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<TeamModel[]>> Get()
        {
            try
            {
                var result = await _repository.GetAllTeamsAsync();
                return _mapper.Map<TeamModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<TeamModel>> Get(string name)
        {
            try
            {
                var result = await _repository.GetTeamByNameAsync(name);
                if (result == null) return NotFound("Team not found");
                return _mapper.Map<TeamModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TeamModel>> Get(int id)
        {
            try
            {
                var result = await _repository.GetTeamByIdAsync(id);
                if (result == null) return NotFound("Team not found!");
                return _mapper.Map<TeamModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("users-in-team/{name}")]
        public async Task<ActionResult<UserNameModel[]>> GetUsers(string name)
        {
            try
            {
                var result = await _repository.GetUsersInTeamAsync(name);
                if (result == null) return NotFound("Users not found!");
                return _mapper.Map<UserNameModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("stats-for-team/{name}")]
        public async Task<ActionResult<StatisticsModel>> GetStats(string name)
        {
            try
            {
                var result = await _repository.GetMainStatisticsAsync(name);
                if (result == null) return NotFound("Statistics not found!");
                return _mapper.Map<StatisticsModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> Post(TeamModel model)
        {
            try
            {
                var team = _mapper.Map<Team>(model);
                if(await _repository.GetTeamByNameAsync(team.Name) != null)
                    return StatusCode(StatusCodes.Status409Conflict, "Team with same name already exists!");
                _repository.Add(team);
                var stats = new Statistics { 
                    Goals = 0,
                    Games = 0,
                    Wins = 0,
                    Draws = 0,
                    Loses = 0,
                    Team = team.Name
                };
                _repository.Add(stats);
                if (await _repository.SaveChangesAsync())
                {
                    var location = _linkGenerator.GetPathByAction(HttpContext,
                       "Get",
                        values: new { id = team.TeamId });
                    return Created(location, _mapper.Map<TeamModel>(team));
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
                var team = await _repository.GetTeamByIdAsync(id);
                if (team == null) return NotFound("Team not found!");
                var entity = await _repository.GetMainStatisticsAsync(team.Name);
                _repository.Delete(entity);
                _repository.Delete(team);
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TeamModel>> Put(int id, TeamModel model)
        {
            try
            {
                var oldTeam = await _repository.GetTeamByIdAsync(id);
                if (oldTeam == null) return NotFound("Does not exists!");
                _mapper.Map(model, oldTeam);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<TeamModel>(oldTeam);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest();
        }

        [HttpPut("add-user")]
        public async Task<ActionResult<TeamModel>> Put(int userid, string team)
        {
            try
            {
                var user = await _repository.GetUserByIdAsync(userid);
                var teamEntity = await _repository.GetTeamByNameAsync(team);
                if (user == null || teamEntity == null) return NotFound("Team or User not found!");
                if (teamEntity.Users.Count() == 2 || teamEntity.Users.Any(t => t.UserId == userid)) 
                    return StatusCode(StatusCodes.Status409Conflict, "Cannot add user to team!");
                teamEntity.Users.Add(user);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<TeamModel>(teamEntity);
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