﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class OtherDBCarDal : ICarDal
    {
        List<Car> otherCars;
        List<Colors> otherColors;
        public OtherDBCarDal()
        {
            otherCars = new List<Car> {
                new Car{ Id=1, BrandId=1, ColorId=1, ModelYear=2016, DailyPrice=250, Description="FORD FOCUS-other cars"},
                new Car{ Id=2, BrandId=1, ColorId=2, ModelYear=2018, DailyPrice=280, Description="FORD FIESTA-other cars"},
                new Car{ Id=3, BrandId=2, ColorId=2, ModelYear=2015, DailyPrice=290, Description="Citroen C1-other cars"},
                new Car{ Id=4, BrandId=3, ColorId=3, ModelYear=2020, DailyPrice=600, Description="AUDİ A1-other cars"},
                new Car{ Id=5, BrandId=4, ColorId=1, ModelYear=2019, DailyPrice=550, Description="HONDA CIVIC-other cars"},

            };
            otherColors = new List<Colors>
            {
                new Colors{ ColorId=1, ColorName="Black"},
                new Colors{ ColorId=2, ColorName="White"},
                new Colors{ ColorId=3, ColorName="Gray"},
                new Colors{ ColorId=4, ColorName="Red"},
                new Colors{ ColorId=5, ColorName="Blue"},
            };
        }
        public void Add(Car car)
        {
            otherCars.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartoDelete = otherCars.SingleOrDefault(c => car.Id == car.Id);
            otherCars.Remove(cartoDelete);
        }

        public List<Car> GetAll()
        {
            return otherCars;
        }

        public Car GetByCarId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetByColorIdx()
        {
            var result = from c in otherCars
                         join co in otherColors
                         on c.ColorId equals co.ColorId
                         select new CarDto { CarId = c.Id, ColorName = co.ColorName, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear };

            return result.ToList();
        }

        public List<Car> GetById(int Id)
        {
            return otherCars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = otherCars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
