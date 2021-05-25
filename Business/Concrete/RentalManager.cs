using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rental;
        public RentalManager(IRentalDal rental,ICardService cardService)
        {
            _rental = rental;
            
        }
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(
                IsRentable(rental));
            if (result != null)
            {
                return result;
            }
            rental.RentDate = DateTime.Now;
            _rental.Add(rental);
            return new SuccessResult();
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
        public IDataResult<Rental> GetAllByCarId(int carId)
        {
             return new SuccessDataResult<Rental>(_rental.GetAll(r => r.CarId == carId).SingleOrDefault());
        }
        public IResult Update(Rental rental)
        {           
            _rental.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
        public IResult IsRentable(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data;
            if (IsDelivered(rental).Success || (rental.RentDate > result.ReturnDate && rental.RentDate >= DateTime.Now))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        public IResult IsDelivered(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data;
            if (result == null || result.ReturnDate != default)
                return new SuccessResult();
            return new ErrorResult();

        }
    }
}
