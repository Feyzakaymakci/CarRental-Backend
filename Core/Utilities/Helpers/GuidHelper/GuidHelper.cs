using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelpers
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString(); 

            //Yüklediğimiz dosya için eşsiz bir isim oluşturduk.
            //Eşşiz bir isim oluşturmamızın nedeni aynı isimde başka bir dosya varsa çakışmasınlar.
            //Dosya eklerken dosyanın adı kendi olmamalı.
            //Guid.NewGuid () => bu metot bize eşsiz bir değer oluşturdu.
            //ToString()=> bununlada string hale getirdik.
            //Guid.NewGuid () => bu ifade bana eşsiz bir değer oluşturdu ToString() bunu kullanarak da ben değerimi 16 lık sayı tabanına çevirdim.
            //Tüm amaç eşsiz bir değer oluşturalım ki aynı isimden dosyalar olursa çakışmasın.
        }
    }
}
