using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByColorId(int ColorId);
        List<Car> GetCarsByBrandId(int BrandId);
        void AddCar(Car car);



    }
}
