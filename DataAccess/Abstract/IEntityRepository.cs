﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T GetByld(Expression<Func<T, bool>> filter);
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        void Add(T entity);
        void Upgrade(T entity);
        void Delete(T entity);
    }
}
