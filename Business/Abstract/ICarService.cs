using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService: IEntityServiceBase<Car>
    {
        IDataResult<List<DtoCarDetail>> GetCarsByColorId(int ColorId);
        IDataResult<List<DtoCarDetail>> GetCarsDetailByBrandId(int BrandId);
        IDataResult<List<DtoCarDetail>> GetCarDetail();
        IDataResult<List<DtoCarDetail>> GetCarDetailByCarId(int carId);

        IDataResult<List<DtoCarDetail>> GetbyBrandIdandColorId(int brandId, int colorId);






    }
}
