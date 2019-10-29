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

        [HttpGet("tournament{id:int}")]
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

        [HttpPost]
        public async Task<ActionResult<MatchModel>> Post(MatchModel model)
        {
            try
            {
                var match = _mapper.Map<Match>(model);
                var tournament = await _repository.GetTournamentById(model.Tournament.TournamentId);
                if (tournament == null) return NotFound("Tournament not found!");
                match.Tournament = tournament;
                _repository.Add(match);
                if (await _repository.SaveChangesAsync())
                {
                    var location = _linkGenerator.GetPathByAction(HttpContext,
                       "Get",
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MatchModel>> Put(int id, MatchModel model)
        {
            try
            {
                var oldMatch = await _repository.GetMatchById(id);
                if (oldMatch == null) return NotFound("Does not exists!");
                _mapper.Map(model, oldMatch);
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
