using Core.Entities.Concrete;
using Core.Utilities.SendMail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly ISendMailHelper _sendMailHalper;

        public SendMailController(ISendMailHelper sendMailHalper)
        {
            _sendMailHalper = sendMailHalper;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromBody] MailModel mailModel)
        {
            var result = await _sendMailHalper.SendAsync(mailModel);
            return Ok(result);
        }
    }
}
