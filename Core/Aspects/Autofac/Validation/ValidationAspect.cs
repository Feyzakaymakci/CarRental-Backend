using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utilities.Interceptors.Class1;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)  //attribute a tipleri type ile atıyoruz. Attribute olduğu için type geçmek zorundayız. 
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))  //Eğer gönderilen validator type bir IValidator değilse o zaman kız diyor. 
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //INvocation castle dynamic proxyden çöz.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Bu satır reflection dır.Çalışma anında bir şeyleri yapabilmemizi sağlar. Buradaki kodda şunu diyor: O validatorType ın bir instanceını oluştur çalışma anında.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //validator type ın çalışma tipini bul yani basetype ını bul basetype ı abstractvalidator sonra onun generic çalıştığı tipini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Onun parametrelerini bul.İlgili metodun birden fazla parametresi olabilir. invocation metot demek unutma! 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
