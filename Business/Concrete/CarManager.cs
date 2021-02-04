using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(p => p.BrandId ==BrandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(c => c.ColorId == ColorId);
            
        }
    }
}
