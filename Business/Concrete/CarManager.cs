using Business.Abstract;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Add(car);

                return new SuccessResult("ARAC EKLENDİ");
            }
            else
            {
                return new ErrorResult("ARAC EKLENEMEDİ.");
            }

        }
    public IResult Delete(int CarId)
        {
            _carDal.Delete(p => p.Id == CarId);
            return new ErrorResult("ARAC SİLİNDİ.");

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), "ÜRÜNLER SİLTELENDİ");

        }

        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == CarId), "ÜRÜN LİSTELENDİ");
        }

        public IDataResult<List<DtoCarDetail>> GetCarDetail()
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(), "ÜRÜN DETAYI GÖSTERİLİYOR.");

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == BrandId), "ÜRÜN LİSTELENDİ");

        }

        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == ColorId), "ÜRÜN LİSTELENDİ");

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("ARAC LİSTELENDİ");
        }
    }
}
