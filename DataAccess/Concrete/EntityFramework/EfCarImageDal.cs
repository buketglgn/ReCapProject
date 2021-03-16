using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapDatabaseContext>, ICarImageDal
    {
        //public DtoCarDetail GetCarsDetail(Expression<Func<DtoCarDetail, bool>> filter = null)
        //{
        //    using (ReCapDatabaseContext context = new ReCapDatabaseContext())
        //    {

        //    }
        //}


    }
}
