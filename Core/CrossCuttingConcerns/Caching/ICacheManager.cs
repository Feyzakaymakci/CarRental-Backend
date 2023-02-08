using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //İstediğimiz tipte olması için iki yöntem kullanabiliriz.Örneğin:
        T Get<T>(string key);
        //veya
        object Get(string key);
        void Add(string key, object data, int duration); //Her şeyi atayabileceğimiz için object seçiyoruz. Birde bu cache de ne kadar duracak duration olarak seçiyoruz. Dakika saat cinsinden tutabiliriz. Ne istiyorsak o cinsten tutabiliriz.

        bool IsAdd(string key); //Cache de var mı?
        void Remove(string key); //Cache den uçurur musun?
        void RemoveByPattern(string pattern); //İsmi get ile başlayanları uçur veya isminde category geçenleri uçur demek istiyoruz. Farklı farklı senaryoları burada yapıyor olucaz.
    }
}
