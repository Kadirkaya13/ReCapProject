using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        
        Car GetCarByBrandld(int brandId);
        Car GetCarByColorld(int colorId);
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        List<CarImageDetailDto> GetCarImageDetails(Expression<Func<Car, bool>> filter = null);


    }
}
