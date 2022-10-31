using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == brandId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
            //return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetails(c => c.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
            //return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAll(c => c.ColorId == colorId));


        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<CarDetailDto> GetDetailById(int carId)
        {
            var result = _carDal.GetCarDetail(c => c.CarId == carId);
            return new SuccessDataResult<CarDetailDto>(result);
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult();
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult();
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }






        //ICarDal _carDal;
        //IBrandService _brandService;

        //public CarManager(ICarDal carDal, IBrandService brandService)
        //{
        //    _carDal = carDal;
        //    _brandService = brandService;
        //}

        ////[SecuredOperation("car.add,admin")]
        //[ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        //public IResult Add(Car car)
        //{
        //    IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId),
        //                        CheckIfBrandLimitExceeded());

        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    _carDal.Add(car);
        //    return new SuccessResult(Messages.CarAddedMessage);

        //}

        //[CacheAspect]
        //public IDataResult<List<Car>> GetAll()
        //{
        //    if (DateTime.Now.Hour == 7)
        //    {
        //        return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
        //    }
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        //}

        //public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        //}

        //[CacheAspect]
        //[PerformanceAspect(5)]
        //public IDataResult<Car> GetById(int id)
        //{
        //    return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        //}

        //public IDataResult<List<CarDetailDto>> GetCarDetails()
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        //}

        //public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        //}

        //public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==brandId));
        //}

        //public IDataResult<List<Car>> GetCarsByCarId(int carId)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == carId));
        //}


        //[ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        //public IResult Update(Car car)
        //{
        //    IResult result = BusinessRules.Run(CheckCarIdExist(car.CarId));

        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    _carDal.Update(car);
        //    return new SuccessResult(Messages.CarUpdated);
        //}

        //private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        //{
        //    var result = _carDal.GetAll(c => c.BrandId == brandId).Count();
        //    if (result > 15)
        //    {
        //        return new ErrorResult(Messages.CarCountOfBrandError);
        //    }
        //    return new SuccessResult();
        //}

        //private IResult CheckIfBrandLimitExceeded()
        //{
        //    var result = _brandService.GetAll();
        //    if (result.Data.Count > 15)
        //    {
        //        return new ErrorResult(Messages.BrandLimitExceeded);
        //    }
        //    return new SuccessResult();
        //}

        //private IResult CheckCarIdExist(int carId)
        //{
        //    var result = _carDal.GetAll(c => c.CarId == carId);
        //    if (result != null)
        //    {
        //        return new ErrorResult();
        //    }
        //    return new SuccessResult();
        //}

        //[TransactionScopeAspect]
        //public IResult AddTransactionalTest(Car car)
        //{
        //    Add(car);
        //    if (car.DailyPrice < 300)
        //    {
        //        throw new Exception("");
        //    }
        //    Add(car);

        //    return null;
        //}


    }
}
