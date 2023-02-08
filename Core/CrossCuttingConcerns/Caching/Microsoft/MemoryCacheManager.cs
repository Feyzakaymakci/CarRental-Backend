using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }


        public T Get<T>(string key)  //Buradaki kodu ezbere bilmen gerekmez hayatın boyunca bir kere doğru kurduktan sonra kodu bir daha yazmazsın. 
        {
            return _memoryCache.Get<T>(key);
        }


        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }


        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _); //Bir şey döndürmesini istemiyorsun o zaman c# ta şöyle bir şey kullanılır out_
        }


        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }


        public void RemoveByPattern(string pattern) //Bellekten silmeye yarıyor bu metot.Bunu da reflection ile yaparız. Reflection çalışma anında elimizde bulunan nesneleri ve olmayanları da yeniden oluşturmak gibi çalışmalar yapabileceğiniz bir yapı. Kısacası kodu çalışma anında oluşturma müdahele etme gibi şeyleri reflection ile yapıyoruz. 
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance); //EntriesCollection diye bir şeyin içine bak. memoryCache in .netcore dökümantasyonunda cache i burada tuttuğunu görürüz.Ben bellekte onu entriescollection ismiyle tutuyorum der.
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic; //Sonra _memoryCache olanları bul 
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection) //Sonrasında her bir cache elemanını gez diyoruz.
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase); //pattern ı bu şekilde oluşturuyoruz.
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList(); //Cache datası içindeki anahtarlardan benim gönderdiğim değere uygun olanlar varsa onları keysToRemove içine at. 

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key); //Uyanları tek tek siliyoruz.
            }
            }
        }

    }

