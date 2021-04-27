using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Data.Psd2.Authorization
{
    internal class AuthorizationManager
    {
        public async Task<string> GetAuthToken()
        {
            string keyId = "SN=5E4299BE"; // Serial number of the downlaoded certificate in hexadecimal code
            string certPath = "/Certificates/"; // path of the downloaded certificates and keys
            string httpHost = "https://api.sandbox.ing.com";
            string reqPath = "/oauth2/token";

            return "";
        }
    }
}
