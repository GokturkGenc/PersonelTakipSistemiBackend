using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }


        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId),
                CheckIfCategoryLimitExceeded());

            if (result != null)
            {
                return result;

            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAddedMessage);

        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count();
            if (result > 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceeded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 10)
            {
                return new ErrorResult(Messages.BrandLimitExceeded);
            }
            return new SuccessResult();
        }

    }
}
