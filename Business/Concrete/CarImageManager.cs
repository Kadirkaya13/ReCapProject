﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
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
        ICarImageDal _carImageDAL;

        public CarImageManager(ICarImageDal carImageDAL)
        {
            _carImageDAL = carImageDAL;
        }



        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null) return result;

            var query = this.Get(carImage.CarId).Data;


            if (query!=null) {
                carImage.ImagePath = FileHelper.SaveImageFile("Images", file);
                carImage.ImageDate = DateTime.Now;
                carImage.CarImageId = query.CarImageId;
                carImage.CarId = carImage.CarId;
                _carImageDAL.Update(carImage);
            }
            
            //if (query.ImagePath.Contains("default"))
            //{
            //    carImage.ImagePath = FileHelper.SaveImageFile("Images", file);
            //    carImage.ImageDate = DateTime.Now;
            //    carImage.CarImageId = query.CarImageId;
            //    carImage.CarId = carImage.CarId;
            //    _carImageDAL.Update(carImage);
            //}
            else
            {
                carImage.ImagePath = FileHelper.SaveImageFile("Images", file);
                carImage.ImageDate = DateTime.Now;
                _carImageDAL.Add(carImage);
            }

            return new SuccessResult(Messages.CarImageAdded);
        }



        ////[SecuredOperation("carimage.add,admin")]
        //[ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]
        //public IResult Add(IFormFile file, CarImage carImage)
        //{
        //    IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    carImage.ImagePath = FileHelper.Add(file);
        //    carImage.ImageDate = DateTime.Now;
        //    _carImageDAL.Add(carImage);
        //    return new SuccessResult(Messages.CarImageAdded);
        //}

        [SecuredOperation("carimage.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.DeleteImageFile(carImage.ImagePath);
            _carImageDAL.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [SecuredOperation("carimage.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.SaveImageFile(_carImageDAL.Get(p => p.CarImageId == carImage.CarImageId).ImagePath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDAL.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDAL.Get(p => p.CarImageId == id));
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDAL.GetAll());
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id), Messages.CarImagesListed);
        }

        //business rules
        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDAL.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageCountOfCarIdError);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\DefaultCar.jpg";
            var result = _carImageDAL.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, ImageDate = DateTime.Now } };
            }
            return _carImageDAL.GetAll(p => p.CarId == id);
        }



    }
}
