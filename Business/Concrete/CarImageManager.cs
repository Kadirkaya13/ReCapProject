using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
        
        public IResult Add(IFormFile file,CarImage carImage)
        {
            var result = BusinessRules.Run(CheckPhotoNumberLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file,FilePaths.CarImages);
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added); 
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CarImage> GetByld(int Id)
        {
            string path = @"\wwwroot\Images\logo.jpg";
            var result = BusinessRules.Run(CheckIfCarImageNull(path ,Id));
            if (result!=null)
            {
                return new SuccessDataResult<CarImage>();
            }
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == Id));

         
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file, FilePaths.CarImages);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckPhotoNumberLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.PhotoNumberlimitExceded);
            }
            return new SuccessResult();
        }
        private IResult CarImageDelete(CarImage carImage)
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

        private IDataResult<List<CarImage>> CheckIfCarImageNull(string yol,int id)
        {
            string path = @"\wwwroot\Images\logo.jpg";
            var result = _carImageDal.GetAll().Where(p=>p.Id==id).Any(i => i.ImagePath != yol);
            if (result)
            {
                _carImageDal.Get(p => p.ImagePath == path);
                return new SuccessDataResult<List<CarImage>>();
            }
            return new ErrorDataResult<List<CarImage>>( _carImageDal.GetAll());

         
        }
    }
}
