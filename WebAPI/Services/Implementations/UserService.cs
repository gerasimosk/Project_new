using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Repositories;
using WebAPI.Services.Validators;

namespace WebAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new System.ArgumentNullException(nameof(userRepository));
        }

        public async Task<ActionResult<List<User>>> GetUsersAsync(int? pageNumber, int? pageSize, string fullName)
        {
            if (pageNumber == null || pageSize == null || pageNumber < 1 || pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("Page number and page size must be greater than zero");
            }
            return await _userRepository.GetUsersAsync(pageNumber, pageSize, fullName);
        }

        public async Task<User> GetUSerById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("The Identity of a user cannot be zero or negative");
            }
            
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            new UserValidator().ValidateUser(user);

            return await _userRepository.AddAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            new UserValidator().ValidateUser(user);

            return await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("The Identity of a user cannot be zero or negative");
            }

            await _userRepository.DeleteUser(id);
        }
    }
}
