using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module //Burada module ı çözümlerken using autofac i seç reflection ı seçme.
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Brand
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance(); //Birisi senden IProductService isterse ona ProductManager instance ı ver demek. Burada yazdığımız şu kodun aynısı:  services.AddSingleton<IBrandService, BrandManager>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            //Car
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            //Color
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            //Customer
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            //Rental
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            //User
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //AutofacYapılandırması
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() //Buradaki kodlar şu demek : Autofac bize aynı zamanda interception görevi görüyor.Çalışan uygulama içerisinde implemente edilen interfaceleri bul onlara onlar için aspectinterselector ı  çağır.Kısacası sizin tüm sınıflarınız için önce şunu (Selector = new AspectInterceptorSelector()--en alttaki kodu )çalıştırıyor. Git bak bu adamın aspecti var mı? diyor.

                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
