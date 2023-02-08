using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken  //Token ne zamana kadar geçerli onun bilgisini verir bu class. Aynı zamanda erişim anahtarı anlamına denk gelir.
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
