﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IColorService
    {
        void GetByld(int Id);
        List<Color> GetAll();
    }
}