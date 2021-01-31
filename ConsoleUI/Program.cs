using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new OtherDBCarDal());
            
            foreach (var car in carManager.GetCars())
            {
                Console.WriteLine(car.Description+"  GÜNLÜK FİYATI:  "+car.DailyPrice);
            }

            
        }
    }
}
