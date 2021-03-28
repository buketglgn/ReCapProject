using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        public IResult AddPayment(Payment payment)
        {
            payment.ProcessDate = DateTime.Now;
            _paymentDal.Add(payment);
            return new SuccessResult("payment tablosuna eklendi");
        }
    }
}
