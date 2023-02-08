using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper //HashingHelper: Hash oluşturmaya ve onu doğrulamaya yarıyor ve hash oluştururken hangi algoritmayı(hmac512) kullanacağımızı söylüyoruz. Doğrularken de yine aynı algoritmayı kullanıyoruz ama passwordSalt ı kullanarak bunu doğruluyoruz.
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //Bizim ona verdiğimiz bir passwordun hashini ve passwordun saltını oluşturacak yapıyı içeriyor.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;  //System.Security.Cryptography.HMACSHA512()) o an kullandığmız bu algoritma key değeri oluşturur.Her kullanıcı için bir key değeri tutar.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //burada out olmamalı çünkü bu değerleri biz vericez. Buradaki hash ile veritabanımızdaki hash eşitse devam, eşit değilse hata ver diyoruz.ComputedHash bizim oluşturduğumuz,passwordHash ise veritabanındaki hash.Buradaki passwordu kullanıcı giricek.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
