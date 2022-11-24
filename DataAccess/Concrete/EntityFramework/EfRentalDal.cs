using Core.DataAccess.EntityFramework;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental,CarDatabaseContext>, IRentalDal
    {

        public RentalDetailDto GetRentalDetail(Expression<Func<Rental, bool>> filter)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from rental in context.Rentals.Where(filter)
                             join car in context.Cars on rental.CarId equals car.CarId
                             join user in context.Users on rental.UserId equals user.UserId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 CarId = car.CarId,
                                 UserId = user.UserId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ImagePath = (from image in context.CarImages where image.CarId == car.CarId select image.ImagePath).FirstOrDefault()
                             };
                return result.SingleOrDefault();

            }
        }

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars on rental.CarId equals car.CarId
                             join user in context.Users on rental.UserId equals user.UserId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 CarId = rental.CarId,
                                 UserId = user.UserId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 ImagePath = (from image in context.CarImages where image.CarId == car.CarId select image.ImagePath).FirstOrDefault()
                             };
                return result.ToList();

            }
        }
    }
}
