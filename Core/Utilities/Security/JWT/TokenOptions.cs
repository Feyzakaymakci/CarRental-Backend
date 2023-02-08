using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions //biz bu tokenoptionları webAPI içinde appsettings içinde tutucaz ama daha nesne tabanlı çalışmak için bu şekilde burada da belirttik.
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
