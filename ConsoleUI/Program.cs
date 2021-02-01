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
            foreach (var car in carManager.GetByColorId(1))
            {
                Console.WriteLine(car.Description + " Rengi:  " + car.ColorId + " ");
            }
            
            foreach (var car in carManager.GetCars())
            {
                Console.WriteLine(car.Description+"  GÜNLÜK FİYATI:  "+car.DailyPrice+" Renk Id si: "+car.ColorId);
            }

            
        }
    }
}
