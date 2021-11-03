using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;
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

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new System.ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        /// <summary>Gets all users.</summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="fullName">The full name.</param>
        /// <returns>List of users.</returns>
        [HttpGet]
        public async Task<List<UserDetails>> GetAllUsers(int? pageNumber, int? pageSize, string fullName)
        {
            var users = await _userService.GetUsersAsync(pageNumber, pageSize, fullName);
            return _mapper.Map<List<UserDetails>>(users.Value);
        }

        /// <summary>Gets the user by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Details of user.</returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<UserDetails> GetUserById(int id)
        {
            var user = await _userService.GetUSerById(id);
            return _mapper.Map<UserDetails>(user);
        }

        /// <summary>Add a user.</summary>
        /// <param name="user">The user.</param>
        [HttpPost]
        public async Task Add([FromBody] UserDetails userDetails)
        {
            var user = _mapper.Map<User>(userDetails);
            await _userService.AddUserAsync(user);
        }

        /// <summary>Updates the specified user.</summary>
        /// <param name="user">The user.</param>
        [HttpPut]
        public async Task Update([FromBody] UserDetails userDetails)
        {
            var user = _mapper.Map<User>(userDetails);
            await _userService.UpdateUserAsync(user);
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
        }
    }
}
