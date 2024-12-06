using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, BaseContext>, IUserOperationClaimDal
    {
        public async Task<List<UserOperationClaimDto>> SearchAsync(int userId)
        {
            using (BaseContext context = new BaseContext())
            {
                var result = from userOperationClaim in context.UserOperationClaims
                             join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.Id
                             where userOperationClaim.UserId == userId
                             select new UserOperationClaimDto 
                             {
                                Id = userOperationClaim.Id,
                                UserId = userOperationClaim.UserId,
                                OperationClaimId = userOperationClaim.OperationClaimId,
                                OperationClaimName = operationClaim.Name
                             };
                return await result.ToListAsync();
            }
        }
    }
}
