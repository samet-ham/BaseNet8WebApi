using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        Task<IDataResult<List<UserOperationClaimDto>>> SearchAsync(int userId);
        Task<IDataResult<UserOperationClaim>> AddAsync(UserOperationClaim operationClaim);
        Task<IResult> UpdateAsync(UserOperationClaim operationClaim);
        Task<IDataResult<UserOperationClaim>> GetAsync(int Id);
        Task<IResult> DeleteAsync(int Id);
    }
}
