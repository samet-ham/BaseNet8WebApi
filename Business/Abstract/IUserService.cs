using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> AddAsync(UserForRegisterDto userForRegisterDto);
        Task<IDataResult<User>> GetByMailAsync(string mail);
    }
}
