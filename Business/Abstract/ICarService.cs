using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetByld(int Id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int Id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int Id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarImageDetailDto>> GetCarImageDetails();
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
