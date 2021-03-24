using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   
    public interface ICardService
    {
        IResult Add(Card fakeCard);
        IResult Delete(Card fakeCard);
        IResult Update(Card fakeCard);
        IDataResult<List<Card>> GetAll();
        IDataResult<Card> GetById(int id);
        IDataResult<List<Card>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(Card fakeCard);
    }
}
