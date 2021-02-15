using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rental;
        public RentalManager(IRentalDal rental)
        {
            _rental = rental;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==DateTime.MinValue)
            {
                return new ErrorResult(Messages.NotReturned);
            }
            _rental.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rental.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {

            return new SuccessDataResult<List<Rental>>(_rental.GetAll(), Messages.Listed);
        }

        public IResult GetByld(int Id)
        {

            _rental.GetByld(u => u.CustomerId == Id);
            return new SuccessResult(Messages.Listed);
        }

        public IResult Update(Rental rental)
        {           
            _rental.Upgrade(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
