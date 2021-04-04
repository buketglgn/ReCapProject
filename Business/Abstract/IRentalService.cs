using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService : IEntityServiceBase<Rental>
    {
        IResult Deliver(Rental rental);
        IDataResult<RentalDetailDto> GetRentalDetailByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalsDetailByUserId(int userId);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetail();
        IDataResult<Rental> GetByCarId(int carId);



    }
}
