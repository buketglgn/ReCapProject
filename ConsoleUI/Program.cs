using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());



            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " " + car.DailyPrice + " " + car.BrandId);
            }

            Console.WriteLine("----------------GetCarsByColorId---------------------");
            foreach (var item in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("ColorId: "+item.ColorId+" "+item.Description + " " + item.DailyPrice + " " + item.BrandId);
            }

            Console.WriteLine("----------------GetCarsByBrandId---------------------");

            foreach (var item in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("BrandId: "+item.BrandId + " " + item.Description + " " + item.DailyPrice + " " + item.BrandId);
            }

            Console.WriteLine("-----------dailyprice>0 ve description uzunlugu>2 olan yeni kayıt eklerken------------");

            carManager.AddCar(new Car {Id=6, BrandId = 2 , ColorId=3, ModelYear=new DateTime(2020,7,9), DailyPrice=560, Description="Yeni eklenen araba2"}) ;

            Console.WriteLine("---car tablosunun son hali-----");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " " + car.DailyPrice + " " + car.BrandId);
            }


            Console.ReadLine();
            
        }
    }
}
