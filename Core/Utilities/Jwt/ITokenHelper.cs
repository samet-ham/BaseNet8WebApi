using Core.Entities.Concrete;
using Core.Entities.Dtos;

namespace Core.Utilities.Jwt
{
    public interface ITokenHelper
    {
        AccessTokenModel CreateToken(User user, List<UserOperationClaimDto> userOperationClaimDtos);
    }
}
