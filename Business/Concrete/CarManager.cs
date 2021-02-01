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
        public List<Car> GetCars()
        {
            return _carDal.GetAll();
        }

        public Car GetCar(int Id)
        {
            return _carDal.GetByCarId(Id);
        }

        public List<CarDto> GetByColorId()
        {
            return _carDal.GetByColorIdx();
        }
    }
}
