using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
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

        public List<Car> GetCarsByBrandId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
