﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Caching;
using Core.Aspects.Autofact.Transaction;
using Core.Aspects.Autofact.Validation;
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
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;

        }

        [SecuredOperation("admin")]
        // [TransactionalScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
             _carDal.Add(car);

              return new SuccessResult(Messages.CarAdded);
           

        }
    public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new ErrorResult(Messages.CarDeleted);

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());

        }

        [CacheAspect]
        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == CarId));
        }

        [CacheAspect]
        public IDataResult<List<DtoCarDetail>> GetCarDetail()
        {

            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails());

        }
        [CacheAspect]
        public IDataResult<List<DtoCarDetail>> GetCarDetailByCarId(int carId)
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(p=>p.Id==carId));

        }
        public IDataResult<List<DtoCarDetail>> GetbyBrandIdandColorId(int brandId ,int colorId)
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(p => p.BrandId == brandId && p.ColorId == colorId));

        }

        [CacheAspect]
        public IDataResult<List<DtoCarDetail>> GetCarsDetailByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(p => p.BrandId == BrandId));

        }

        [CacheAspect]
        public IDataResult<List<DtoCarDetail>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(c => c.ColorId == ColorId));

        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        
    }
}
