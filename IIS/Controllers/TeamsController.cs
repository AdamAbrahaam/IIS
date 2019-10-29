using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        [HttpGet]
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

                return _mapper.Map<TeamModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("users-in-team{id}")]
        public async Task<ActionResult<UserModel>> GetUsers(int id)
        {
            try
            {
                var result = await _repository.GetUsersInTeamAsync(id);

                return _mapper.Map<UserModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("stats-for-team")]
        public async Task<ActionResult<StatisticsModel[]>> GetStats(string name)
        {
            try
            {
                var result = await _repository.GetStatisticsForTeamAsync(name);
                if (result == null) return NotFound("Statistics not found!");
                return _mapper.Map<StatisticsModel[]>(result);
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
                _repository.Add(team);
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
                if (team == null) return NotFound("User not found!");
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
    }
}