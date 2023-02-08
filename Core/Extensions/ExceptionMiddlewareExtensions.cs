using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();  //.netcore ekibi usemiddleware ile bizi yükten kurtarmış ve yazmış biz sadece çalışmasını istediğimiz kodu yazıcaz.
        }
    }
}
