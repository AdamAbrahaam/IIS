using AutoMapper;
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
        public async Task<ActionResult<TournamentModel[]>> Get() {
            try
            {
                var result = await _repository.GetAllTournamentsAsync();

                return _mapper.Map<TournamentModel[]>(result);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }
    }
}
