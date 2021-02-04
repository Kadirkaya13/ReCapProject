using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarsDbContext context= new CarsDbContext())
            {
                if (entity.DailyPrice>0)
                {
                    var addadEntity = context.Entry(entity);
                    addadEntity.State = EntityState.Added;               
                    context.SaveChanges();

                }
                else
                {
                    throw (new Exception("Geçersiz Bilgi girdiniz"));
                }
            }
        }

        public void Delete(Car entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
            
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetByld(Expression<Func<Car, bool>> filter)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public Car GetCarByBrandld(Expression<Func<Car, bool>> filter)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public Car GetCarByColorld(Expression<Func<Car, bool>> filter)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public void Upgrade(Car entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
