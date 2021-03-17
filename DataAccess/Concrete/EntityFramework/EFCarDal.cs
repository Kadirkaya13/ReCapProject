using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EfEntityRepositoryBase<Car, CarsDbContext>, ICarDal
    {   
       
        public Car GetCarByBrandld(int brandId)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<Car>().SingleOrDefault(b=>b.BrandId==brandId);
            }
        }
        public Car GetCarByColorld(int colorId)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<Car>().SingleOrDefault(c=>c.ColorId==colorId);
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId=c.CarId,
                                 BrandName=b.BrandName,
                                 ColorName=cl.ColorName,
                                 CarName=c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice=c.DailyPrice,
                                 Description = c.Description,
                             };
                return result.ToList();
            }
        }

        public List<CarImageDetailDto> GetCarImageDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join ci in context.CarImages
                             on c.CarId equals ci.CarId
                             select new CarImageDetailDto
                             {
                                 CarId = c.CarId,                               
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = ci.ImagePath
                                 
                             };

                 return result.ToList();
            }
        }
    }
}
