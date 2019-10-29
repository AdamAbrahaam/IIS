using AutoMapper;
using IIS.Data.Entities;
using IIS.Models;
using IIS.Repositories.Interfaces;
using IIS.Services;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public UsersController(IUsersRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> PostLogin(UserModel user)
        {
            try
            {
                var userEntity = await _repository.GetUserByEmailAsync(user.Email);
                if (userEntity == null) return NotFound("User Not Found!");

                var hasher = new PasswordHasher(user.Password);
                if (hasher.Compare(userEntity.Password)) 
                    return _mapper.Map<UserModel>(userEntity);
                else 
                    return Unauthorized("Incorrect password!");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to login User!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            try
            {
                var user = await _repository.GetUserByIdAsync(id);
                if (user == null) return NotFound("User Not Found!");

                return _mapper.Map<UserModel>(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get User!");
            }
        }

        [HttpGet("stats-for-user{id:int}")]
        public async Task<ActionResult<StatisticsModel[]>> GetStats(int id)
        {
            try
            {
                var user = await _repository.GetUserByIdAsync(id);
                if (user == null) return NotFound("User Not Found!");
                var result = await _repository.GetStatistics(id);
                return _mapper.Map<StatisticsModel[]>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure!");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> PostRegister(UserModel model)
        {
            try
            {
                var location = _linkGenerator.GetPathByAction(
                    "Get",
                    "Users",
                    new { email = model.Email });
                var user = _mapper.Map<User>(model);
                _repository.Add(user);
                if (await _repository.SaveChangesAsync())
                {
                    return Created(location, _mapper.Map<UserModel>(user));
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
                var user = await _repository.GetUserByIdAsync(id);
                if (user == null) return NotFound("User not found!"); 
                _repository.Delete(user);
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserModel>> Put(int id, UserModel model)
        {
            try
            {
                var oldStat = await _repository.GetUserByIdAsync(id);
                if (oldStat == null) return NotFound("Does not exists!");
                _mapper.Map(model, oldStat);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<UserModel>(oldStat);
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
