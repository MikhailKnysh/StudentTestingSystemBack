namespace STS.Common.SMTP.Service
{
    public interface IMailSenderService
    {
        void SendMessageWithPassword(string destMail, string messageBody);
    }
}