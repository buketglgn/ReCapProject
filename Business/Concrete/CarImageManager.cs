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
        
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }
        public IResult Add(CarImage carImage)
        {
            var results = BusinessRules.Run(CheckIfImageCount(carImage.CarId));
            if (results!=null)
            {
                return results;
            }
            carImage.Date = DateTime.Now.Date;
            var addedCarImage = CreatedFile(carImage).Data;
            _carImageDal.Add(addedCarImage);
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
           
            _carImageDal.Update(carImage);
            return new SuccessResult("Image updated");
        }

        private string ImagePath(CarImage carImage)
        {
            string namePathRule = "CAR-" + carImage.CarId + "-" + DateTime.Now.ToShortDateString();
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

        private IResult CheckIfImageCount(int CarId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == CarId);
            if(result.Count >= 5)
            {
                return new ErrorResult("bu araca ait 5 ten fazla resim olamaz.");

            }
            return new SuccessResult();
        }

         private IDataResult<CarImage> CreatedFile(CarImage carImage)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");
            var differentFileName = Guid.NewGuid().ToString() + "-" + DateTime.Now.ToShortDateString();

            string source = Path.Combine(carImage.ImagePath);
            string result = $@"{path}\{differentFileName}";
            try
            {

                File.Move(source, path + @"\" + differentFileName);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<CarImage>(exception.Message);
            }

            return new SuccessDataResult<CarImage>
                (new CarImage 
                { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now }
                , "resim eklendi");
           
        }

       
    }
}