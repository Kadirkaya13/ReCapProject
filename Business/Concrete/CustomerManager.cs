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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customer;
        public CustomerManager(ICustomerDal customer)
        {
            _customer = customer;
        }
        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.Invalid);
            }
            _customer.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _customer.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {

            return new SuccessDataResult<List<Customer>>(_customer.GetAll(), Messages.Listed);
        }

        public IDataResult<Customer> GetByld(int Id)
        {

            
            return new SuccessDataResult<Customer>(_customer.Get(u => u.CustomerId == Id),Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.Invalid);
            }
            _customer.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
