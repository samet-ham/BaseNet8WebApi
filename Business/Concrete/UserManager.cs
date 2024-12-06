using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly HashingHelper _hashingHelper;

        public UserManager(IUserDal userDal, HashingHelper hashingHelper)
        {
            _userDal = userDal;
            _hashingHelper = hashingHelper;
        }

        public async Task<IDataResult<User>> GetByMailAsync(string mail)
        {
            var user = await _userDal.GetAsync(x => x.Mail == mail && x.Active == true);
            return new SuccessDataResult<User>(user);
        }

        public async Task<IDataResult<User>> AddAsync(UserForRegisterDto userForRegisterDto)
        {
            // Şifre hash'leme
            byte[] passwordHash, passwordSalt;
            _hashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var newUser = new User
            {
                Active = true,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Mail = userForRegisterDto.Mail,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await _userDal.AddAsync(newUser);
            return new SuccessDataResult<User>(newUser);
        }
    }
}
