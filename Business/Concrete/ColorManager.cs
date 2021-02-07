using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(int colorID)
        {
            _colorDal.Delete(p => p.ColorId == colorID);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll().ToList();
        }

        public Color GetById(int Id)
        {
            return _colorDal.Get(p => p.ColorId == Id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
