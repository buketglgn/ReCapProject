using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Caching;
using Core.Aspects.Autofact.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Entities.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rental;
        private ICarService _carService;


        //true müsaitlik anlamında;
        public RentalManager(IRentalDal rental, ICarService carService)
        {
            _rental = rental;
            _carService = carService;
        }

        [CacheRemoveAspect("IRentalService.Get")]
       //[SecuredOperation("user,admin")]
       [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental Tentity)
        {
            IResult results = BusinessRules.Run(CheckIfCarInUse(Tentity.CarId));
            if (results != null)
            {
                return results;
            }
            
         _rental.Add(Tentity);
             return new SuccessResult(Messages.RentalAdded);
        }

        
        public IResult Delete(Rental rental)
        {
            IResult results = BusinessRules.Run(CheckIfDelete(rental.Id));
            if (results != null)
            {
                return results;
            }
            
            _rental.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);

        }

        //bu metot çagrıldıgında arac teslim edildi.
        //teslim edilme tarihi verildi.
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Deliver(Rental rental)
        {
            IResult results = BusinessRules.Run(CheckIfDeliver(rental.Id));
            if (results != null)
            {
                return results;
            }
            
            return new SuccessResult(Messages.RentalDelivered);

        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll());
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rental.Get(p => p.Id == Id));
        }
        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rental.Get(p => p.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<RentalDetailDto> GetRentalDetailByCarId(int carId)
        {

            var result = _rental.GetRentalDetails(r => r.CarId == carId).LastOrDefault();
            return new SuccessDataResult<RentalDetailDto>(result, Messages.RentalGetAllSuccess);
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rental.GetRentalDetails(),
                Messages.RentalGetAllSuccess);
        }



        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental Tentity)
        {
            _rental.Update(Tentity);
            return new SuccessResult(Messages.RentalUpdated);
        }
       

        private IResult CheckIfCarInUse(int carId)
        {
            //bu degerlere sahip bir sey döndürüyorsa arac kullanımdadır
            var results = _rental.GetAll(r => r.CarId == carId);
            foreach (var result in results)
            {
                if (result.ReturnDate == null || result.RentDate > result.ReturnDate)
                {
                    return new ErrorResult(Messages.RentalCheckIsCarReturnError);
                }
            }

            return new SuccessResult();

        }

        private IResult CheckIfDelete(int Id)
        {
            var result = _rental.Get(p => p.Id == Id);
            if (result == null)
            {
                return new ErrorResult(Messages.NoRecording);
            }
           
            return new SuccessResult();
        }

        private IResult CheckIfDeliver(int rentalId)
        {
            var result = _rental.Get(p => p.Id == rentalId);
            if (result.ReturnDate != null)
            {
                return new ErrorResult(Messages.NoRecording);
            }
            result.ReturnDate = DateTime.Now.Date;
            Update(result);
            return new SuccessResult();
        }

       
    }
}
