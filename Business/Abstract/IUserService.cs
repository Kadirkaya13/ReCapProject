using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByld(int Id);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<List<OperationClaim>> GetCleaims(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
