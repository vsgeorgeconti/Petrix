using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petrix.Application.DTOs.Auth
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}