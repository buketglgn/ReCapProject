using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofact.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var results = BusinessRules.Run(CheckIfImageCount(carImage.CarId));
            if (results!=null)
            {
                return results;
            }
            var addedCarImage = CreatedFile(carImage).Data;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfDeleteImage(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p=>p.Id==Id));

        }
        public IDataResult<List<CarImage>> GetAllImagesByCarId(int CarId)
        {
           
            return new SuccessDataResult<List<CarImage>>(CheckIfDefaultImages(CarId));
        }


        [ValidationAspect(typeof(ImageValidator))]
        public IResult Update(CarImage carImage)
        {

            var updatedCarImage = UpdatedFile(carImage).Data;
            _carImageDal.Update(carImage);
            return new SuccessResult("Image updated");
        }

        private IResult CheckIfDeleteImage(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfDefaultImages(int Id)
        {
            var DefaultPath = AppDomain.CurrentDomain.BaseDirectory + "C:\\Users\\Lenovo\\Desktop\\walpapers\\logo.jpg";


            var result = _carImageDal.GetAll(p => p.CarId == Id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = Id, ImagePath = DefaultPath, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p=>p.CarId==Id);
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
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Image");
            var uniqueFilename = Guid.NewGuid().ToString("N")
                +"CAR-"+carImage.CarId+"-"+DateTime.Now.ToShortDateString();

            string source = Path.Combine(carImage.ImagePath);

            string result = $@"{path}\{uniqueFilename}";

            try
            {

                File.Move(source, path + @"\" + uniqueFilename);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<CarImage>(exception.Message);
            }

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now },"resim eklendi");
        }
        public IDataResult<CarImage> UpdatedFile(CarImage carImage)
        {
            var uniqueFilename = Guid.NewGuid().ToString("N")
               + "CAR-" + carImage.CarId + "-" + DateTime.Now.ToShortDateString();

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $"{path}\\{uniqueFilename}";

            File.Copy(carImage.ImagePath, path + "\\" + uniqueFilename);
            File.Delete(carImage.ImagePath);

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now });

        }


    }
}