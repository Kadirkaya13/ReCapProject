using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ColorId);
            }
            //CarCRUD();
            //ColorCRUD();
            //BrandCRUD();
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Id={0} Brand={1} Color={2} Price={3}",car.CarId,car.BrandName,car.ColorName,car.DailyPrice);
            }
           

        }

        private static void BrandCRUD()
        {
            Brand brand1 = new Brand { BrandId = 8, BrandName = "Honda" };
            Brand brand2 = new Brand { BrandId = 8, BrandName = "BMW" };
            EFBrandDal eFBrandDal = new EFBrandDal();
            //eFBrandDal.Add(brand1);
            //eFBrandDal.Upgrade(brand2);
            //eFBrandDal.Delete(brand2);
        }

        private static void ColorCRUD()
        {
            Color color1 = new Color { ColorId = 12, ColorName = "Açık Yeşil" };
            Color color2 = new Color { ColorId = 12, ColorName = "Açık Kahve" };
            EFColorDal eFColorDal = new EFColorDal();
            eFColorDal.Add(color1);
            eFColorDal.Upgrade(color2);
            eFColorDal.Delete(color2);
        }

        private static void CarCRUD()
        {
            Car car1 = new Car { CarId = 4, BrandId = 2, ColorId = 4, DailyPrice = 870000, Description = "Lüks araç", ModelYear = new DateTime(2020, 1, 1) };
            Car car2 = new Car { CarId = 5, BrandId = 2, ColorId = 4, DailyPrice = 870000, Description = "Lüks araç", ModelYear = new DateTime(2020, 1, 1) };
            Car car3 = new Car { CarId = 5, BrandId = 2, ColorId = 4, DailyPrice = 870000, Description = "araç", ModelYear = new DateTime(2020, 1, 1) };

            EFCarDal eFCarDal = new EFCarDal();
            eFCarDal.Add(car2);
            eFCarDal.Delete(car1);
            eFCarDal.Upgrade(car3);
        }
    }
}
