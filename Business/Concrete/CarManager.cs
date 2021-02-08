using Business.Abstract;
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
      

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void GetByld(int car_Id)
        {
            _carDal.GetByld(c => c.CarId == car_Id);
        }

        public List<Car> GetByUnitPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice <= min && c.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
