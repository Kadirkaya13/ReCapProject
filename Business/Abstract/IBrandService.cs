using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        void GetByld(int Id);
        List<Brand> GetAll();
    }
}
