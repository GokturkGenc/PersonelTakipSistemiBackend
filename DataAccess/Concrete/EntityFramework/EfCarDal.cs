using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDatabaseContext>, ICarDal
    {
        public CarDetailDto GetCarDetail(Expression<Func<Car, bool>> filter)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from car in context.Cars.Where(filter)
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 //ImagePath = context.CarImages.Where(c => c.CarId == car.CarId).ToList()
                                 ImagePath = (from image in context.CarImages where image.CarId == car.CarId select image.ImagePath).FirstOrDefault()
                             };
                return result.SingleOrDefault();

            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 //ImagePath = context.CarImages.Where(ci => ci.CarId == car.CarId).FirstOrDefault()
                                 ImagePath = (from image in context.CarImages where image.CarId == car.CarId select image.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorAndBrand(int colorId,int brandId)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from car in context.Cars 
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             where color.ColorId == colorId & brand.BrandId == brandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 //ImagePath = context.CarImages.Where(ci => ci.CarId == car.CarId).FirstOrDefault()
                                 ImagePath = (from image in context.CarImages where image.CarId == car.CarId select image.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
    }

}


