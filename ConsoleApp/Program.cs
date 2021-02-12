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
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.ColorId);
            }
            //CarCRUD();
            //ColorCRUD();
            //BrandCRUD();
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine("Id={0} Brand={1} Color={2} Price={3}",car.CarId,car.BrandName,car.ColorName,car.DailyPrice);
            }
           

        }

        private static void BrandCRUD()
        {
            Brand brand1 = new Brand { BrandId = 8, BrandName = "Honda" };
            Brand brand2 = new Brand { BrandId = 8, BrandName = "BMW" };
            BrandManager brandManager =new BrandManager(new EFBrandDal());
            brandManager.Add(brand1);
            brandManager.Update(brand2);
            brandManager.Delete(brand2);
        }

        private static void ColorCRUD()
        {
            Color color1 = new Color { ColorId = 12, ColorName = "Açık Yeşil" };
            Color color2 = new Color { ColorId = 12, ColorName = "Açık Kahve" };
            ColorManager colorManager = new ColorManager(new EFColorDal());
            colorManager.Add(color1);
            colorManager.Update(color2);
            colorManager.Delete(color2);
        }

        private static void CarCRUD()
        {
            Car car1 = new Car { CarId = 4, BrandId = 2, ColorId = 4, DailyPrice = 870000, Description = "Lüks araç", ModelYear = new DateTime(2020, 1, 1) };
           
            Car car3 = new Car { CarId = 5, BrandId = 2, ColorId = 4, DailyPrice = 870000, Description = "araç", ModelYear = new DateTime(2020, 1, 1) };

            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car { CarId = 4, BrandId = 2, ColorId = 4, DailyPrice = 870000, Description = "Lüks araç", ModelYear = new DateTime(2020, 1, 1) });
            carManager.Delete(car1);
            carManager.Update(car3);
        }
    }
}
