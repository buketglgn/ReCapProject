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
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rental;


        //true müsaitlik anlamında;
        public RentalManager(IRentalDal rental)
        {
            _rental = rental;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("Kullanici")]
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

        //rental tablosundan silindi.
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
        public IResult Deliver(int rentalId)
        {
            IResult results = BusinessRules.Run(CheckIfDeliver(rentalId));
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

        [CacheAspect]
        public IDataResult<List<Rental>> InUse()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll(p => p.ReturnDate == null));
        }

        [CacheAspect]
        public IDataResult<List<Rental>> NotInUse()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll(p => p.ReturnDate != null));
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental Tentity)
        {
            _rental.Update(Tentity);
            return new SuccessResult(Messages.RentalUpdated);
        }
        [CacheAspect]
        public IDataResult<List<DtoRentalDetail>> GetRentalDetails()
        {
            return new SuccessDataResult<List<DtoRentalDetail>>(_rental.GetRentalDetails());


        }

        private IResult CheckIfCarInUse(int carId)
        {
            //bu degerlere sahip bir sey döndürüyorsa arac kullanımdadır
            var result = _rental.Get(p => p.CarId ==carId && p.ReturnDate == null);
            if (result != null)
            {
                return new ErrorResult(Messages.RentalBusy);
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
            if (result.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalBusy);
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
