using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryCarDal : ICarDal
    //{
    //    List<Car> _cars;
    //    public InMemoryCarDal()
    //    {
    //            _cars = new List<Car>()
    //            {
    //                new Car{ CarId=1,ColorId=1,BrandId=1,ModelYear=2018,DailyPrice=300,Description="Otomatik Vites" },
    //                new Car{ CarId=2,ColorId=2,BrandId=3,ModelYear=2020,DailyPrice=400,Description="Düz Vites" },
    //                new Car{ CarId=3,ColorId=1,BrandId=3,ModelYear=2022,DailyPrice=330,Description="Otomatik Vites" },
    //                new Car{ CarId=4,ColorId=3,BrandId=1,ModelYear=2021,DailyPrice=320,Description="Otomatik Vites" },
    //                new Car{ CarId=5,ColorId=1,BrandId=2,ModelYear=2020,DailyPrice=450,Description="Düz Vites" },
    //                new Car{ CarId=6,ColorId=2,BrandId=3,ModelYear=2017,DailyPrice=250,Description="Otomatik Vites" },
    //            };
    //    }


    //    public void Add(Car car)
    //    {
    //        _cars.Add(car);
    //    }

    //    public void Delete(Car car)
    //    {
    //        Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
    //        _cars.Remove(carToDelete);
    //    }

    //    public Car Get(Expression<Func<Car, bool>> filter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _cars;
    //    }

    //    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<CarDetailDto> GetCarsByBrandId(int brandId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<CarDetailDto> GetCarsByCarId(int CarId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<CarDetailDto> GetCarsByColorId(int colorId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAllById(int CarId)
    //    {
    //        return _cars.Where(c=>c.CarId == CarId).ToList();
    //    }

    //    public List<CarDetailDto> GetCarDetails()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Car car)
    //    {
    //        Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
    //        carToUpdate.DailyPrice = car.DailyPrice;
    //        carToUpdate.ModelYear = car.ModelYear;
    //        carToUpdate.BrandId = car.BrandId;
    //        carToUpdate.ColorId = car.ColorId;
    //        carToUpdate.Description = car.Description;
    //    }
    //}
}
