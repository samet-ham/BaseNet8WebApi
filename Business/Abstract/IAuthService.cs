using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<DataResult<User>> Register(UserForRegisterDto userForRegisterDto);
        Task<DataResult<User>> Login(UserForLoginDto userForLoginDto);
    }
}
