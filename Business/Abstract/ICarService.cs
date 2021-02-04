using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void GetByld(int Id);
        List<Car> GetAll();
        List<Car> GetByUnitPrice(decimal min, decimal max);
        List<Car> GetCarsByBrandId(int Id);
        List<Car> GetCarsByColorId(int Id);
        
        
        
    }
}
