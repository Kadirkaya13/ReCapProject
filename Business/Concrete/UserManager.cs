using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(UsersValidator))]
        public IResult Add(User user)
        {
            
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
            
            _user.Upgrade(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
