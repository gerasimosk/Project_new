using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Exceptions;
using WebAPI.Services;
using WebAPI.Services.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new System.ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>Gets all users.</summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="fullName">The full name.</param>
        /// <returns>List of users.</returns>
        [HttpGet]
        public async Task<ActionResult<List<UserDetailsDTO>>> GetAllUsers(int pageNumber, int pageSize, string fullName)
        {
            try
            {
                var users = await _userService.GetUsersAsync(pageNumber, pageSize, fullName);

                var usersAfterMapping = _mapper.Map<List<UserDetailsDTO>>(users);

                return Ok(usersAfterMapping);
            }
            catch (Exception ex) when (ex is ArgumentOutOfRangeException)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw ex;
            }
        }

        /// <summary>Gets the user by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Details of user.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserById([FromRoute] int id)
        {
            try
            {
                var userDetails = await _userService.GetUserByIdAsync(id);

                var userDetailsAfterMapping = _mapper.Map<UserDetailsDTO>(userDetails);

                return Ok(userDetailsAfterMapping);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex) when (ex is EntityNotFoundException)
            {
                _logger.LogError(ex.Message);

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw ex;
            }
        }

        /// <summary>Add a user.</summary>
        /// <param name="user">The user.</param>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserDetailsDTO userDetails)
        {
            try
            {
                var user = _mapper.Map<User>(userDetails);

                await _userService.AddUserAsync(user);

                return Ok();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw ex;
            }
        }

        /// <summary>Updates the specified user.</summary>
        /// <param name="user">The user.</param>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserDetailsDTO userDetails)
        {
            try
            {
                var user = _mapper.Map<User>(userDetails);

                await _userService.UpdateUserAsync(user);

                return Ok();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw ex;
            }
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);

                return Ok();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
            catch (Exception ex) when (ex is EntityNotFoundException)
            {
                _logger.LogError(ex.Message);

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw ex;
            }
        }
    }
}
