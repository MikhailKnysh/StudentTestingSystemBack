using System;
using System.Globalization;

namespace STS.Common.Auth.Models
{
    public class AuthModelForCreateToken
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}