using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper //Uyduruk stringlerle encryption a parametre geçemiyoruz. Onu bir byte[] haline getirmemiz lazım. SecurityKeyHelper onu bir byte[] haline getirmeye yarıyor. Ve sonrasında onun byte ını alıp symmetric security anahtar haline getirir.
    { 
        public static SecurityKey CreateSecurityKey(string securityKey) //SecurityKey i Microsoft Identity Model Tokens ile çözümle.
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
        
    }
}
