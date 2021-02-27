using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{CarId=1,BrandId=1,ColorId=3,ModelYear=new DateTime(1999,1,1),DailyPrice=40000,Description="Fast car" },
                new Car{CarId=2,BrandId=1,ColorId=4,ModelYear=new DateTime(1970,1,1),DailyPrice=40000,Description="Classic" },
                new Car{CarId=3,BrandId=2,ColorId=2,ModelYear=new DateTime(2015,1,1),DailyPrice=40000,Description="Sport car" },
                new Car{CarId=4,BrandId=2,ColorId=3,ModelYear=new DateTime(2018,1,1),DailyPrice=40000,Description="Economic car" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void GetByld(int car_Id)
        {
            Car getCarById = _cars.SingleOrDefault(c => c.CarId == car_Id);
            Console.WriteLine(getCarById.ModelYear); 
        }

        public Car GetByld(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetCarByBrandld(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetCarByBrandld(int brandId)
        {
            throw new NotImplementedException();
        }

        public Car GetCarByColorld(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetCarByColorld(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            car.BrandId = carToUpdate.BrandId;
            car.ColorId = carToUpdate.ColorId;
            car.DailyPrice = carToUpdate.DailyPrice;
            car.Description = carToUpdate.Description;
            
               
        }
    }
}
