using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Jwt;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<DataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userService.GetByMailAsync(userForLoginDto.Email);
            return new SuccessDataResult<User>(user.Data);
        }

        public async Task<DataResult<User>> Register(UserForRegisterDto userForRegisterDto)
        {
            var user = await _userService.AddAsync(userForRegisterDto);
            return new SuccessDataResult<User>(user.Data);
        }
    }
}
