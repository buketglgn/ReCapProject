using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDatabaseContext>, IRentalDal
    {
        public List<DtoRentalDetail> GetRentalDetails()
        {
            using (ReCapDatabaseContext context=new ReCapDatabaseContext())
            {
                var result = from re in context.Rentals
                             join ca in context.Cars
                             on re.CarId equals ca.Id
                             join cu in context.Customers
                             on re.CustomerId equals cu.UserId
                             join us in context.Users
                             on cu.UserId equals us.Id
                             select new DtoRentalDetail
                             {
                                 Id = re.Id,
                                 Descripton = ca.Description,
                                 CompanyName = cu.CompanyName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 UserName = us.FirstName + " " + us.LastName,
                                 DailyPrice=ca.DailyPrice
                             };
                 return result.ToList();
            }
        }

    }
}
