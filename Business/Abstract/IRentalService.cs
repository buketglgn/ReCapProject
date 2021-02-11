using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService : IEntityServiceBase<Rental>
    {
      IResult Deliver(int rentalId);
      IDataResult<List<Rental>> GetAvailableCars();
     IDataResult<List<Rental>> GetUnAvailableCars();



    }
}
