using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromQuery] SearchCustomerDto searchCustomerDto)
        {
            var result = await _customerService.SearchAsync(searchCustomerDto);
            if (result.Success) return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCustomerDto addCustomerDto)
        {
            var result = await _customerService.AddAsync(addCustomerDto);
            if (result.Success) return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var result = await _customerService.UpdateAsync(updateCustomerDto);
            if (result.Success) return Ok(result);
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _customerService.GetAsync(id);
            if (result.Success) return Ok(result);
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.DeleteAsync(id);
            if (result.Success) return Ok(result);
            return BadRequest();
        }
    }
}
