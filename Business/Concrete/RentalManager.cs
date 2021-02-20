using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.CrossCuttingConcerns.Validation;
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

        //[ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental Tentity)
        {
            //bu degerlere sahip bir sey döndürüyorsa arac kullanımdadır.
            var result = _rental.Get(p => p.CarId == Tentity.CarId && p.ReturnDate == null);
            if (result != null)
            {
                return new ErrorResult(Messages.RentalBusy);
            }
            else
            {
                _rental.Add(Tentity);
            }
            
            return new SuccessResult(Messages.RentalAdded);
        }

        //rental tablosundan silindi.
        public IResult Delete(int Id)
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
            _rental.Delete(p => p.Id == Id);
            return new SuccessResult(Messages.RentalDeleted);

        }

        //bu metot çagrıldıgında arac teslim edildi.
        //teslim edilme tarihi verildi.
        public IResult Deliver(int rentalId)
        {
            var result = _rental.Get(p => p.Id == rentalId);
            result.ReturnDate = DateTime.Now.Date;
            Update(result);
            return new SuccessResult(Messages.RentalDelivered);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll());
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rental.Get(p => p.Id == Id));
        }


        public IDataResult<List<Rental>> InUse()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll(p => p.ReturnDate == null));
        }

        public IDataResult<List<Rental>> NotInUse()
        {
            return new SuccessDataResult<List<Rental>>(_rental.GetAll(p => p.ReturnDate != null));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental Tentity)
        {
            _rental.Update(Tentity);
            return new SuccessResult(Messages.RentalUpdated);
        }
        public IDataResult<List<DtoRentalDetail>> GetRentalDetails()
        {
            return new SuccessDataResult<List<DtoRentalDetail>>(_rental.GetRentalDetails());


        }
    }
}
