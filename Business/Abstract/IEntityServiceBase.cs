using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IEntityServiceBase<T>
    {
        IResult Add(T Tentity);
        IResult Delete(T Tentity);
        IResult Update(T Tentity);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int Id);
    }
}
