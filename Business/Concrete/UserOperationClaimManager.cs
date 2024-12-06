using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public async Task<IDataResult<UserOperationClaim>> AddAsync(UserOperationClaim operationClaim)
        {
            await _userOperationClaimDal.AddAsync(operationClaim);
            return new SuccessDataResult<UserOperationClaim>(operationClaim);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var result = await GetAsync(Id);
            await _userOperationClaimDal.DeleteAsync(result.Data);
            return new SuccessResult();
        }

        public async Task<IDataResult<UserOperationClaim>> GetAsync(int Id)
        {
            var result = await _userOperationClaimDal.GetAsync(x => x.Id == Id);
            return new SuccessDataResult<UserOperationClaim>(result);
        }

        public async Task<IDataResult<List<UserOperationClaimDto>>> SearchAsync(int userId)
        {
            var result = await _userOperationClaimDal.SearchAsync(userId);
            return new SuccessDataResult<List<UserOperationClaimDto>>(result);
        }

        public async Task<IResult> UpdateAsync(UserOperationClaim operationClaim)
        {
            await _userOperationClaimDal.UpdateAsync(operationClaim);
            return new SuccessResult();
        }
    }
}
