using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public async Task<IDataResult<OperationClaim>> AddAsync(OperationClaim operationClaim)
        {
            await _operationClaimDal.AddAsync(operationClaim);
            return new SuccessDataResult<OperationClaim>(operationClaim);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var result = await GetAsync(Id);
            await _operationClaimDal.DeleteAsync(result.Data);
            return new SuccessResult();
        }

        public async Task<IDataResult<OperationClaim>> GetAsync(int Id)
        {
            var result = await _operationClaimDal.GetAsync(x => x.Id == Id);
            return new SuccessDataResult<OperationClaim>(result);
        }

        public async Task<IDataResult<List<OperationClaim>>> SearchAsync(OperationClaim operationClaim)
        {
            var result = await _operationClaimDal.GetListAsync();
            return new SuccessDataResult<List<OperationClaim>>(result.ToList());
        }

        public async Task<IResult> UpdateAsync(OperationClaim operationClaim)
        {
            await _operationClaimDal.UpdateAsync(operationClaim);
            return new SuccessResult();
        }
    }
}
