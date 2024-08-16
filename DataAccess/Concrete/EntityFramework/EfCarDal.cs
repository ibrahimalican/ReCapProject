﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext renACarContext = new RentACarContext())
            {
                var result = from c in renACarContext.Cars
                             join b in renACarContext.Brands
                             on c.BrandId equals b.BrandId
                             join co in renACarContext.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { CarName = c.CarName, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
