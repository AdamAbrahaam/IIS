using AutoMapper;
using IIS.Data;
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

        [HttpGet("stats-for-user")]
        public async Task<ActionResult<StatisticsModel[]>> Get(int id)
        {
            try
            {
                var result = await _repository.GetStatisticsForUser(id);
                return _mapper.Map<StatisticsModel[]>(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpGet("stats-for-team")]
        public async Task<ActionResult<StatisticsModel>> GetStatisticsForTeam(int id)
        {
            try
            {
                var result = await _repository.GetStatisticsForTeam(id);
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
                var result = await _repository.GetStatisticsUserRanking();
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
                var result = await _repository.GetStatisticsTeamRanking();
                return _mapper.Map<StatisticsModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StatisticsModel>> Post(StatisticsModel model)
        {
            try
            {
                var location = _linkGenerator.GetPathByAction(
                    "Get",
                    "Statistics",
                    new { hash = model.GetHashCode()});
                var statistics = _mapper.Map<Statistics>(model);
                statistics.User = await _repository.GetUserById(model.User.UserId);
                //statistics.Team = await _repository.GetTeamById(model.Team.TeamId);
                _repository.Add(statistics);
                if (await _repository.SaveChangesAsync())
                {
                    return Created(location, _mapper.Map<StatisticsModel>(statistics));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var statistics = await _repository.GetStatisticsById(id);
                _repository.Delete(statistics);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!");
            }
            return BadRequest("Failed to delete statistics");
        }

        [HttpPut]
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
