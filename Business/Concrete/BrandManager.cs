using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExists(brand.BrandName));

            if (result != null)
            {
                return result;

            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAddedMessage);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfBrandNameExists(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExists);
            }
            return new SuccessResult();
        }


    }
}
