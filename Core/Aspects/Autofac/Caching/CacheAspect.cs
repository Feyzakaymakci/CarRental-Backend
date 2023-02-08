using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); //ReflectedType.FullName: Namespace+Managerını al demek ya da Namespace + Interface ini al demek.
            var arguments = invocation.Arguments.ToList(); //Arguments(Parametre) Metodun parametreleri varsa listeye çevir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; //Metodun parametre değeri varsa getall un içerisine ekliyoruz. Eğer parametreyi vermediysek null olduğunu söyleriz. Buarada string.join bir araya getirmek demek. İki tane soru işareti şu demek varsa şunu ekle yoksa şunu ekle demek.
            if (_cacheManager.IsAdd(key)) //Bellekte var mı git bak bakalım.
            {
                invocation.ReturnValue = _cacheManager.Get(key); //Eğer cache varsa sen metodu çalıştırmadan geri dön demek. Kendin manuel bir return oluşturuyorsun. 
                return;
            }
            invocation.Proceed(); //Cache yoksa metodu devam ettir. 
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //Metot çalışmaya devam edince veritabanından datayı getirdi.Key, returnvalue, duration buraya eklenmiş olucak. 
        }
    }
}
