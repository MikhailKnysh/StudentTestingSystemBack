using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using STS.Common.SMTP.Models;

namespace STS.Common.SMTP.Service
{
    public class MailSenderService : IMailSenderService
    {
        private readonly SmtpConfig _smtpConfig;

        public MailSenderService(IOptions<SmtpConfig> options)
        {
            _smtpConfig = options.Value;
        }

        public void SendMessageWithPassword(string destMail, string messageBody)
        {
            var from = new MailAddress(_smtpConfig.SenderMail, _smtpConfig.SenderName);

            var client = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = new NetworkCredential(_smtpConfig.SenderMail, _smtpConfig.SenderPassword)
            };

            var to = new MailAddress(destMail);
            var massage = new MailMessage(from, to)
            {
                Body = messageBody,
                Subject = "Your password in STS",
            };
            massage.IsBodyHtml = true;

            client.Send(massage);
        }
    }
}