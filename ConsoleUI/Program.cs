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
            // CrudOperationsOfColor();
            //CrudOperationsOfBrand();
            //CrudOperationsOfCar();

            // Console.ReadLine();

            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User
            //{
            //    FirstName = "Bülent",
            //    LastName="Gül",
            //    Email="agsga",
            //    Password="000"

            //});

            //foreach (var user in userManager.GetAll().Data)
            //{
            //    Console.WriteLine(user.FirstName+" "+user.LastName);
            //}


            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //foreach (var rentalDetail in rentalManager.GetRentalDetails().Data)
            //{
            //    Console.WriteLine(rentalDetail.UserName+"/"+rentalDetail.Descripton+"/"+rentalDetail.DailyPrice+"/"+rentalDetail.RentDate);
            //}
            //foreach (var item in rentalManager.GetAvailableCars().Data)
            //{
            //    Console.WriteLine(item.Id+"/"+item.CarId+"/"+item.CustomerId+"/"+item.RentDate);
            //}

            //var result=rentalManager.Add(new Rental
            //{
            //    CarId = 6,
            //    CustomerId = 2,
            //    RentDate = new DateTime(2016, 7, 9),
            //});

            //var result= rentalManager.Add(new Rental
            // {
            //     CarId = 4,
            //     CustomerId = 2,
            //     RentDate = new DateTime(2018, 7, 9),
            // });

            //Console.WriteLine(result.Message);

            //foreach (var rentalCar in rentalManager.GetAll().Data)
            //{
            //    Console.WriteLine(rentalCar.CustomerId + " " + rentalCar.Id + "/" + rentalCar.CarId + "/" + rentalCar.RentDate);
            //}

            //  Console.WriteLine( rentalManager.Delete(10).Message);

            //ıd si 15 olan kayıt teslim ediliyor
            // Console.WriteLine(rentalManager.Deliver(15).Message);
        }
        
        //private static void CrudOperationsOfCar()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //     foreach (var detail in carManager.GetCarDetail().Data)
        //                {
        //                    Console.WriteLine(detail.Description+"/"+ detail.BrandName+"/"+detail.ColorName+"/" +detail.DailyPrice);
        //                }
      
           // carManager.AddCar(new Car { Id = 7, ColorId = 3, BrandId = 2, ModelYear = new DateTime(2018, 7, 9), DailyPrice = 500, Description = "YENİ EKLENEN " });
           // carManager.Update(new Car { Id = 7, ColorId = 3, BrandId = 2, ModelYear = new DateTime(2018, 7, 9), DailyPrice = 555, Description = "YENİ EKLENENFiyatGüncellendi 2 . kez " } );
            //carManager.DeleteCar(5);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description + " " + car.DailyPrice + " " + car.BrandId);
            //}

            //Console.WriteLine("----------------GetCarsByColorId---------------------");
            //foreach (var item in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine("ColorId: " + item.ColorId + " " + item.Description + " " + item.DailyPrice + " " + item.BrandId);
            //}

            //Console.WriteLine("----------------GetCarsByBrandId---------------------");

            //foreach (var item in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine("BrandId: " + item.BrandId + " " + item.Description + " " + item.DailyPrice + " " + item.BrandId);
            //}

            //Console.WriteLine("-----------dailyprice>0 ve description uzunlugu>2 olan yeni kayıt eklerken------------");

            //carManager.AddCar(new Car { Id = 6, BrandId = 2, ColorId = 3, ModelYear = new DateTime(2020, 7, 9), DailyPrice = 560, Description = "Yeni eklenen araba2" });

            //Console.WriteLine("---car tablosunun son hali-----");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description + " " + car.DailyPrice + " " + car.BrandId);
            //}
        }

        //private static void CrudOperationsOfColor()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    Console.WriteLine("COLOR Id si 2 olan gösterilitor..");
        //    Console.WriteLine(colorManager.GetById(2).Data.ColorName);


        //    colorManager.Add(new Color { ColorId = 6, ColorName = "yellow" });
        //    colorManager.Update(new Color { ColorId = 6, ColorName = "NewYellow" });
        //    colorManager.Delete(5);

        //        foreach (var color in colorManager.GetAll().Data)
        //                    {
        //                        Console.WriteLine(color.ColorName);
        //                    }
            
           
            
        //}
        //private static void CrudOperationsOfBrand()
        //{
//            BrandManager brandManager = new BrandManager(new EfBrandDal());
//            Console.WriteLine(brandManager.GetById(2).Data.BrandName);
//            brandManager.Add(new Brand { BrandId = 5, BrandName = "Ferrari" });
//            brandManager.Update(new Brand { BrandId = 6, BrandName = "NewBrandd" });
//            brandManager.Delete(5);

//            foreach (var brand in brandManager.GetAll().Data)
//            {
//                Console.WriteLine(brand.BrandName);
//            }
//        }


//}
}
