using BLL.Contracts;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUsersService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> IsUserExistAsync(UserDto userDto)
        {
            return (await _repository.IsUserExistByNameAsync(userDto.UserNick, userDto.UserPassword) || await _repository.IsUserExistByEmailAsync(userDto.UserEmail, userDto.UserPassword));
        }

        public async Task<bool> IsUserExistByEmailAsync(UserDto userDto)
        {
            return await _repository.IsUserExistByEmailAsync(userDto.UserEmail, userDto.UserPassword);
        }


        public async Task<UserDto> FindUserAsync(UserDto userDto)
        {
            //UserEmail = nickOrEmail
            var user = await _repository.FindUserAsync(userDto.UserEmail, userDto.UserPassword);
            if (user != null)
                return new UserDto
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserPassword = user.Password,
                    UserRole = user.Roles.ToList()
                };
            return null;
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            await _repository.AddUserToDatabaseAsync(userDto.UserNick, userDto.UserEmail, userDto.UserPassword);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user != null)
                return new UserDto
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserPassword = user.Password,
                    UserRole = user.Roles.ToList()
                };
            return null;
        }

        public async Task AddAttemptAsync(AttemptDTO attemptDto)
        {
            await _repository.AddAttemptToDatabaseAsync(attemptDto.NickOrEmail, attemptDto.IpAddress, attemptDto.IsSuccess);
        }

        public async Task<bool> IsUserExistByNameAsync(UserDto userDto)
        {
            return await _repository.IsUserExistByNameAsync(userDto.UserNick, userDto.UserPassword);
        }

        public int GetUsersId(string nickOrEmail)
        {
            if (nickOrEmail.Contains('@')) 
                return _repository.GetUsersIdByEmail(nickOrEmail);
            return _repository.GetUsersIdByName(nickOrEmail);

        }
    }
}
