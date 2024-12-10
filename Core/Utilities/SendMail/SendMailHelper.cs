using Core.Entities.Concrete;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.SendMail
{
    public class SendMailHelper : ISendMailHelper
    {
        private readonly IConfiguration _configuration;

        public SendMailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SendAsync(MailModel mailModel)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings").Get<SmtpSettings>();

                using (var client = new SmtpClient(smtpSettings.Host, smtpSettings.Port))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpSettings.From, smtpSettings.Password);

                    var message = new MailMessage(smtpSettings.From, mailModel.To)
                    {
                        Subject = mailModel.Subject,
                        Body = mailModel.Body,
                        IsBodyHtml = true
                    };

                    await client.SendMailAsync(message);
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
