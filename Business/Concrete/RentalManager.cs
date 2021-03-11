using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IDataResult<Rental> GetByld(int Id)
        {

            
            return new SuccessDataResult<Rental>(_rental.Get(u => u.CustomerId == Id),Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rental.GetRentalDetails(), Messages.Listed);
        }

        public IResult Update(Rental rental)
        {           
            _rental.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
