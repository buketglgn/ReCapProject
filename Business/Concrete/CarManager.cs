using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }


        public void AddCar(Car car)
        {
            if(car.DailyPrice>0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
            }
            
        }

        public void DeleteCar(int CarId)
        {
            _carDal.Delete(p => p.Id == CarId);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetByCarId(int CarId)
        {
            return _carDal.Get(p => p.Id == CarId);
        }

        public List<DtoCarDetail> GetCarDetail()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(p => p.BrandId ==BrandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(c => c.ColorId == ColorId);
            
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
