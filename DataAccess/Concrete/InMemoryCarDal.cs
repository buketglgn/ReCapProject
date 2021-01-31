﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> cars;
        public InMemoryCarDal()
        {
            cars = new List<Car> { 
                new Car{ Id=1, BrandId=1, ColorId=1, ModelYear=2016, DailyPrice=220, Description="FORD FOCUS"},
                new Car{ Id=2, BrandId=1, ColorId=2, ModelYear=2018, DailyPrice=260, Description="FORD FIESTA"},
                new Car{ Id=3, BrandId=2, ColorId=2, ModelYear=2015, DailyPrice=250, Description="Citroen C1"},
                new Car{ Id=4, BrandId=3, ColorId=3, ModelYear=2020, DailyPrice=500, Description="AUDİ A1"},
                new Car{ Id=5, BrandId=4, ColorId=1, ModelYear=2019, DailyPrice=450, Description="HONDA CIVIC"},

            };
        }
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = cars.SingleOrDefault(c => c.Id == car.Id); //tek bir data döndürecekse kullan.
            cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetById(int Id)
        {
            return cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
