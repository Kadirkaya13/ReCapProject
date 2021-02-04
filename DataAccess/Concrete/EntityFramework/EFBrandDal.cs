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
    public class EFBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                if (entity.BrandName.Length>=2)
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

        public void Delete(Brand entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public Brand GetByld(Expression<Func<Brand, bool>> filter)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public void Upgrade(Brand entity)
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
