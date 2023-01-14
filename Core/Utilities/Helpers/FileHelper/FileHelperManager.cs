using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper //Projeye yüklenecek dosyalarla ilgili add,update,delete işlemlerini bu classta yapıyoruz.
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0) //Dosya uzunluğunu bayt olarak alır. Dosya gönderilmiş mi gönderilmemiş mi onu kontrol eder.
            {
                if (!Directory.Exists(root)) 
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName); //Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
                string guid = GuidHelper.CreateGuid(); //Dosyamıza eşşiz bir isim veriyoruz.
                string filePath = guid + extension; //Dosyanın oluşturulan adını ve uzantısını yan yana getiriyoruz.Resim yükleyeceğimiz için bu dosyanın uzantısı .jpg olacak.

                using (FileStream fileStream = File.Create(root + filePath)) ////Burada en başta FileStrem class'ının bir örneği oluşturulu., sonrasında File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.(Upload işlemi yaptığımız için bu aşama var)
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath; // burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
                }
            }
            return null;
        }
    }
}

//IFormFile projemize bir dosya yüklemek için kulanılan yöntemdir, HttpRequest ile gönderilen bir dosyayı temsil eder.
//FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır
