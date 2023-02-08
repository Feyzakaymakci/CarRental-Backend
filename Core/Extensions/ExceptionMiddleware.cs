using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)  //API çalıştığında bizim en küçük yapımız bile bu metotdan geçiyor önce. Tüm kodlarımızı trycatch in içine almış oluyoruz. 

        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)  
        {
            httpContext.Response.ContentType = "application/json"; //Burada tarayıcımıza diyoruz ben sana bir tane json yolladım haberin olsun. 
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;  //burada httpstatuscode dan sonra istediğimiz mesajı verebiliyoruz otomatik çıkıyor 

            string message = "Internal Server Error"; //Olur da bir hata olursa error mesajı verdik
            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException)) //Burada ise şunu diyoruz eğer aldığım hata validationException ise şu mesajı ver ekrana
            {
                message = e.Message; //e. deyince exception hatalarını alırız.
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400; //400 bad request tir.  Hatanın türünü burada kontrol ettik. Eğer doğrulama hatasıysa o doğrulama hatasıne göre bir dönüş gerçekleştirdik. Yanlış kontrollerle sistemde bug oluişturabiliriz bu yüzden bunu yazmaktan vazgeç.
                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode=400,
                    Message=message,
                    Errors=errors
                }.ToString());  //ErrorDetails ile aslında hata mesajının detayını düzenledik.  

            }

            return httpContext.Response.WriteAsync(new ErrorDetails  //Eğer olur da sistem hata verirse şunu dön diyoruz.
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
