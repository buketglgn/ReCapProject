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
        IDataResult<List<Car>> GetCarsByColorId(int ColorId);
        IDataResult<List<Car>> GetCarsByBrandId(int BrandId);
        IDataResult<List<DtoCarDetail>> GetCarDetail();



    }
}
