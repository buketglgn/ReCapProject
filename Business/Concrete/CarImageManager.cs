using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        int i = 0;
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }
        public IResult Add(CarImage carImage)
        {
            if (_carImageDal.GetAll(p => p.CarId == carImage.CarId).Count > 4)
            {
                return new ErrorResult("bu araca ait 5 ten fazla resim olamaz.");
            }

            string createPath = ImagePath(carImage);
            File.Copy(carImage.ImagePath, createPath);
            carImage.ImagePath = createPath;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("resim eklendi");
        }

        public IResult Delete(int Id)
        {
            var ImageDelete = _carImageDal.Get(p => p.Id == Id);
            File.Delete(ImageDelete.ImagePath);
            _carImageDal.Delete(p => p.Id == Id);
            return new SuccessResult("Image Deleted");


        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return null;

        }
        public IDataResult<List<CarImage>> GetAllImagesByCarId(int CarId)
        {
            CheckIfDefaultImages(CarId);
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == CarId));
        }
            


        public IResult Update(CarImage carImage)
        {
            var updatePath = ImagePath(carImage);
            File.Copy(carImage.ImagePath, updatePath);
            File.Delete(carImage.ImagePath);
            carImage.ImagePath = updatePath;
            _carImageDal.Update(carImage);
            return new SuccessResult("Image updated");
        }

        private string ImagePath(CarImage carImage)
        {
            string namePathRule = "CAR-" + carImage.CarId + "-" + DateTime.Now.ToShortDateString() + i++;
            return AppDomain.CurrentDomain.BaseDirectory + "Images\\" + namePathRule + ".jpg";
        }

        private IResult CheckIfDefaultImages(int Id)
        {
            var DefaultPath = AppDomain.CurrentDomain.BaseDirectory + "C:\\Users\\Lenovo\\Desktop\\walpapers\\logo.jpg";
            var result = _carImageDal.GetAll(p => p.CarId == Id);
            if (result.Count==0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = DefaultPath } });
            }
            return null;
        }

        
    }
}