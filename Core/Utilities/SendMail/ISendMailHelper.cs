using Core.Entities.Concrete;

namespace Core.Utilities.SendMail
{
    public interface ISendMailHelper
    {
        Task<string> SendAsync(MailModel mailModel);
    }
}
