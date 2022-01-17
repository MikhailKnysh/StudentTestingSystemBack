using System.Threading.Tasks;

namespace STS.Common.SMTP.Service
{
    public interface IMailSenderService
    {
        Task SendMessageWithPasswordAsync(string destMail, string password);
        Task SendMessageWithInviteAsync(string destMail, string theme);
    }
}