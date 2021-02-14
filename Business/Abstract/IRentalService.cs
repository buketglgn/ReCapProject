using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService : IEntityServiceBase<Rental>
    {
      IResult Deliver(int rentalId);
      IDataResult<List<Rental>> InUse();
     IDataResult<List<Rental>> NotInUse();
        IDataResult<List<DtoRentalDetail>> GetRentalDetails();



    }
}
