using Business.Abstract;
using Business.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Hashing;
using Core.Utilities.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly HashingHelper _hashingHelper;
        private readonly JwtHelper _jwtHelper;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, HashingHelper hashingHelper, JwtHelper jwtHelper, IUserOperationClaimService userOperationClaimService, IUserService userService)
        {
            _authService = authService;
            _hashingHelper = hashingHelper;
            _jwtHelper = jwtHelper;
            _userOperationClaimService = userOperationClaimService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            //Mail adresi kontrolü
            var user = await _authService.Login(userForLoginDto);
            if (user.Data == null) 
                return Unauthorized("E-mail address not found");

            //Şifre kontrolü
            if (!_hashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
                return Unauthorized("Invalid password");

            //İzileri bulma
            var claims = await _userOperationClaimService.SearchAsync(user.Data.Id);

            //Careate Token göndereceğiz
            var accessTokenModel = _jwtHelper.CreateToken(user.Data, claims.Data.ToList());
            return Ok(accessTokenModel);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //Mail adresi kontrolü
            var user = await _userService.GetByMailAsync(userForRegisterDto.Mail);
            if (user.Data != null)
                return BadRequest("This email address is already in use");

            //Yeni kayıt
            var newUser = await _authService.Register(userForRegisterDto);
            if (newUser.Data == null)
                return BadRequest("An error occurred");

            //Boş claims oluştur 
            List<UserOperationClaimDto> claims = new List<UserOperationClaimDto>();

            //Token oluştur
            var accessTokenModel = _jwtHelper.CreateToken(newUser.Data, claims.ToList());

            return Ok(accessTokenModel);
        }
    }
}
