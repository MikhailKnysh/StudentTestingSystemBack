namespace STS.Common.Auth.Models
{
    public class Token
    {
        public string Bearer { get; set; }
        public int Expires { get; set; }
    }
}