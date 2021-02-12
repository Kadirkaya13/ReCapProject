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
    public class UserManager : IUserService
    {
        IUserDal _user;
        public UserManager(IUserDal user)
        {
            _user = user;
        }
        public IResult Add(User user)
        {
            if (user.FirstName.Length<2||user.LastName.Length<2)
            {
                return new ErrorResult(Messages.Invalid);
            }
            _user.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _user.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            
            return new SuccessDataResult<List<User>>(_user.GetAll(),Messages.Listed);
        }

        public IResult GetByld(int Id)
        {

            _user.GetByld(u=>u.Id==Id);
            return new SuccessResult(Messages.Listed);
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length < 2 || user.LastName.Length < 2)
            {
                return new ErrorResult(Messages.Invalid);
            }
            _user.Upgrade(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
