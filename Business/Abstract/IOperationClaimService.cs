using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IDataResult<List<OperationClaim>>> SearchAsync(OperationClaim operationClaim);
        Task<IDataResult<OperationClaim>> AddAsync(OperationClaim operationClaim);
        Task<IResult> UpdateAsync(OperationClaim operationClaim);
        Task<IDataResult<OperationClaim>> GetAsync(int Id);
        Task<IResult> DeleteAsync(int Id);
    }
}
