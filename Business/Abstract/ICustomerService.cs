using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICustomerService : IEntityServiceBase<Customer>
    {
        IDataResult<List<DtoCustomerDetail>> GetCustomersDetails();
    }
}
