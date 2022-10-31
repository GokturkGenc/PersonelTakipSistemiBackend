using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetDetailById(int carId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);


        //IDataResult<Car> GetById(int carId);
        //IDataResult<List<Car>> GetAll();
        //IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        //IDataResult<List<Car>> GetCarsByColorId(int colorId);
        //IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        //IDataResult<List<CarDetailDto>> GetCarDetails();
        //IResult Add(Car car);
        //IResult Update(Car car);
        //IResult AddTransactionalTest(Car car);
    }
}
