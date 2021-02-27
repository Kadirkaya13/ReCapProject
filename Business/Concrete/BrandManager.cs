﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _brandDal.Add(brand);
           return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand brand)
        {
            if (_brandDal!=brand)
            {
                return new ErrorResult(Messages.Invalid);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Brand> GetByld(int brandId)
        {
           
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId),Messages.Listed);
        }

        public IResult Update(Brand brand)
        {
            if (_brandDal != brand)
            {
                return new ErrorResult(Messages.Invalid);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }

      
    }
}
