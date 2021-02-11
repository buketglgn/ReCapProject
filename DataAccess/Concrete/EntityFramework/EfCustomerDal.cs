using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Concrete
{
   public class EfCustomerDal: EfEntityRepositoryBase<Customer, ReCapDatabaseContext>, ICustomerDal
    {
    }
}
