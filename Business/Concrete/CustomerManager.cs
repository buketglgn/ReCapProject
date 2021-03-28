using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
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

        //[SecuredOperation("Kullanici")]
        public IResult Add(Customer Tentity)
        {
            _customerDal.Add(Tentity);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
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

        public IDataResult<List<DtoCustomerDetail>> GetCustomersDetails()
        {
            return new SuccessDataResult<List<DtoCustomerDetail>>(_customerDal.GetCustomersDetail());
        }

        public IResult Update(Customer Tentity)
        {
            _customerDal.Update(Tentity);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
