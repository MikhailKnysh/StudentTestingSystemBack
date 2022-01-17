using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using STS.Common.SMTP.Models;

namespace STS.Common.SMTP.Service
{
    public class MailSenderService : IMailSenderService
    {
        private readonly SmtpConfig _smtpConfig;
        private readonly SmtpClient _smtpClient;
        private readonly MailAddress _mailAddressFrom;

        public MailSenderService(IOptions<SmtpConfig> options)
        {
            _smtpConfig = options.Value;
            _smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = new NetworkCredential(_smtpConfig.SenderMail, _smtpConfig.SenderPassword)
            };
            _mailAddressFrom = new MailAddress(_smtpConfig.SenderMail, _smtpConfig.SenderName);
        }

        public async Task SendMessageWithPasswordAsync(string destMail, string password)
        {
            var to = new MailAddress(destMail);
            var massage = new MailMessage(_mailAddressFrom, to)
            {
                Body = password,
                Subject = "Your password in STS",
            };
            massage.IsBodyHtml = true;

            _smtpClient.Send(massage);
        }

        public async Task SendMessageWithInviteAsync(string destMail, string theme)
        {
            var to = new MailAddress(destMail);
            var massage = new MailMessage(_mailAddressFrom, to)
            {
                Body = $"You have been invited to take a test on {theme}. Visit the portal to take the test.",
                Subject = "Invite to test",
            };
            massage.IsBodyHtml = true;

            _smtpClient.Send(massage);
        }
    }
}