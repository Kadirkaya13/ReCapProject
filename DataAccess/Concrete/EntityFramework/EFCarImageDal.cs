using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarImageDal : EfEntityRepositoryBase<CarImage, CarsDbContext>, ICarImageDal
    {
        public CarImage GetByCarld(int carId)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<CarImage>().SingleOrDefault(c => c.CarId == carId);
            }
        }
    }
}
