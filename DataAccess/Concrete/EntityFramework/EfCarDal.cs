using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDatabaseContext>, ICarDal
    {
        public List<DtoCarDetail> GetCarDetails(Expression<Func<DtoCarDetail, bool>> filter = null)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             //join ci in context.CarImages
                             //on c.Id equals ci.CarId
                             select new DtoCarDetail
                             {
                                 Id = c.Id,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 MinFindexScore=c.MinFindexScore,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()

                             };



                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
        //public DtoCarDetail GetCarDetailsByCarId(int carId)
        //{
        //    using (ReCapDatabaseContext context = new ReCapDatabaseContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.BrandId
        //                     join co in context.Colors
        //                     on c.ColorId equals co.ColorId

        //                     select new DtoCarDetail
        //                     {
        //                         Id = c.Id,
        //                         Description = c.Description,
        //                         BrandName = b.BrandName,
        //                         BrandId = b.BrandId,
        //                         ColorId = co.ColorId,
        //                         ColorName = co.ColorName,
        //                         DailyPrice = c.DailyPrice,
        //                         ModelYear = c.ModelYear,
        //                         Status = !context.Rentals.Any(p => p.CarId == carId && p.ReturnDate == null),


        //                     }; 
        //        return result.SingleOrDefault();
        //    }


        //}

    }
}

