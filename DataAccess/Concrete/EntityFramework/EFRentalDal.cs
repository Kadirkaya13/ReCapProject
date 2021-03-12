using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EfEntityRepositoryBase<Rental, CarsDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var result = from r in context.Rentals
                                 join c in context.Cars on r.CarId equals c.CarId
                                 join cu in context.Customers on r.CustomerId equals cu.CustomerId
                                 join u in context.Users on cu.UserId equals u.Id
                                 join b in context.Brands on c.BrandId equals b.BrandId
                                 select new RentalDetailDto
                                 {
                                     Id = r.Id,
                                     BrandName = b.BrandName,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate,
                                 };
                    return result.ToList();
            }
        }
    }
}
