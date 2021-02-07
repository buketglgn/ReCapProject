using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetAll();
        Car GetByCarId(int CarId);
        List<Car> GetCarsByColorId(int ColorId);
        List<Car> GetCarsByBrandId(int BrandId);
        void AddCar(Car car);
        void DeleteCar(int CarId);
        void Update(Car car);
        List<DtoCarDetail> GetCarDetail();



    }
}
