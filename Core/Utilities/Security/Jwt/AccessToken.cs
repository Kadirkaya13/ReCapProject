using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public string token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
