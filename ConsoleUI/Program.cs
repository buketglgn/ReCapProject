using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("seçilen Id ye göre bir araba listeleniyor..");
            Console.WriteLine(carManager.GetCar(2).Description+"  "+carManager.GetCar(2).DailyPrice);


            Console.WriteLine("-----------------------------------");
            Console.WriteLine("seçilen renge göre arabalar listeleniyor.." );
            foreach (var item in carManager.GetByColorId())
            {
                Console.WriteLine("Car Id si: " +item.CarId+" rengi: "+item.ColorName+" günlük fiyatı "+item.DailyPrice);

            }
            
            
            foreach (var car in carManager.GetCars())
            {
                Console.WriteLine(car.Description+"  GÜNLÜK FİYATI:  "+car.DailyPrice+" Renk Id si: "+car.ColorId);
            }

            
        }
    }
}
