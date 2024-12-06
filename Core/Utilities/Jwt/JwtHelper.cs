using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private readonly JwtSettings _jwtSettings;

        public JwtHelper(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public AccessTokenModel CreateToken(User user, List<UserOperationClaimDto> userOperationClaimDtos)
        {
            if (_jwtSettings.Key == null) throw new Exception("Jwt is null!");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Mail),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            // Rolleri ayrı ayrı claim olarak ekleme
            claims.AddRange(userOperationClaimDtos.Select(role =>
                new Claim(ClaimTypes.Role, role.OperationClaimName)));

            var token = new JwtSecurityToken(_jwtSettings.Issuer,
                                             _jwtSettings.Audience,
                                             claims,
                                             expires: DateTime.Now.AddDays(1),
                                             signingCredentials: credentials);

            AccessTokenModel accessTokenModel = new AccessTokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = DateTime.Now.AddDays(1)
            };

            return accessTokenModel;
        }
    }
}
