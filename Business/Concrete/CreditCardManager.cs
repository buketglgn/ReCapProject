using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCard;
        public CreditCardManager(ICreditCardDal creditCard)
        {
            _creditCard = creditCard;
        }
        public IResult Add(CreditCard Tentity)
        {
            _creditCard.Add(Tentity);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Delete(CreditCard Tentity)
        {
            _creditCard.Delete(Tentity);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll().ToList());
        }

        public IDataResult<CreditCard> GetById(int Id)
        {
            return new SuccessDataResult<CreditCard>(_creditCard.Get(p => p.Id == Id));
        }

        public IDataResult<List<CreditCard>> GetAllByUserId(int UserId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll(p => p.UserId == UserId).ToList());

        }

        public IResult Update(CreditCard Tentity)
        {

            _creditCard.Update(Tentity);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
