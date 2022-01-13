namespace STS.Common.SMTP.Models
{
    public class SmtpConfig
    {
        public string SenderMail { get; set; }
        public string SenderPassword { get; set; }
        public string SenderName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        
    }
}