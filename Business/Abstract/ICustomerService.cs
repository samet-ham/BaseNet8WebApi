using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<List<CustomerDto>>> SearchAsync(SearchCustomerDto searchCustomerDto);
        Task<IDataResult<Customer>> AddAsync(AddCustomerDto addCustomerDto);
        Task<IResult> UpdateAsync(UpdateCustomerDto updateCustomerDto);
        Task<IDataResult<Customer>> GetAsync(int id);
        Task<IResult> DeleteAsync(int id);
    }
}
