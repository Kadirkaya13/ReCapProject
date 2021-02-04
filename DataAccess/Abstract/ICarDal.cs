using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        Car GetCarByBrandld(Expression<Func<Car, bool>> filter);
        Car GetCarByColorld(Expression<Func<Car, bool>> filter);


    }
}
