using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer Tentity)
        {
            _customerDal.Add(Tentity);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(int Id)
        {
            _customerDal.Delete(p=>p.UserId==Id);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int Id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.UserId == Id));
        }

        public IResult Update(Customer Tentity)
        {
            _customerDal.Update(Tentity);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
