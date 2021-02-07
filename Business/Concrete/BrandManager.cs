using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(int brandId)
        {
            _brandDal.Delete(p => p.BrandId == brandId);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll().ToList();
        }

        public Brand GetById(int Id)
        {
            return _brandDal.Get(p => p.BrandId == Id);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
