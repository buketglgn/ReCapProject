using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICustomerDal: IEntityRepository<Customer>
    {
        List<DtoCustomerDetail> GetCustomersDetail();
    }
}
