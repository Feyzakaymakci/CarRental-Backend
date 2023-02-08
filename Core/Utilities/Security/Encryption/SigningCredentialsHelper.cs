using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper //Web API'ya diceksin ki JWT sistemini yöneteceksin senin anahtarın budur,şifreleme algoritman da budur diyeceksin. Yani kısaca WebaPI ya da söylüyoruz anahtarı ve güvenlik algoritmasını
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
        //Anahtar olarak securityKey i kullan. Şifreleme olarak da güvenlik algoritmalarından HmacSha512 yi kullan diyoruz.
    }
}
