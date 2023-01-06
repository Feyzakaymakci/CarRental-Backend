using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using static Core.Utilities.Interceptors.Class1;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)  //method ınfo reflection ile çöz.
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();   //ilgili classın attributelarını oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true); //İlgili metodun attributelarını oku
            classAttributes.AddRange(methodAttributes); 
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //Otomatik olarak sistemdeki tüm metotları log a dahil et demek. Şuan loglama altyapısı yok bu yüzden bu metodu kullanmıyoruz.

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //Çalışma sırasını da öncelik değerine()priorty) göre sırala
        }
    }
}
