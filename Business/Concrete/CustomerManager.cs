using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager(IMapper mapper, ICustomerDal customerDal)
        {
            _mapper = mapper;
            _customerDal = customerDal;
        }

        public Task<IDataResult<Customer>> AddAsync(AddCustomerDto addCustomerDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<Customer>> GetAsync(int id)
        {
            var result = await _customerDal.GetAsync(x => x.Id == id && x.Active == true);
            return new SuccessDataResult<Customer>(result);
        }

        public async Task<IDataResult<List<CustomerDto>>> SearchAsync(SearchCustomerDto searchCustomerDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(UpdateCustomerDto updateCustomerDto)
        {
            throw new NotImplementedException();
        }
    }
}
