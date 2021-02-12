using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
       
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
            
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
             
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        public IResult GetByld(int car_Id)
        {
            _carDal.GetByld(c => c.CarId == car_Id);
            return new SuccessResult(Messages.Listed);
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
                
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice <= min && c.DailyPrice <= max),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
             
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
             
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
             
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),Messages.Listed);
        }

        public IResult Update(Car car)
        {
            _carDal.Upgrade(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
