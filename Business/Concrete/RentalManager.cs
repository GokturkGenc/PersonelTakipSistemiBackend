using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;
        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }

        //[ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsCarAvailableForSelectedDates(rental));
            if (result != null)
            {
                return new ErrorResult(Messages.RentalDenied);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalConfirm);
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalConfirm);
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalConfirm);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll().ToList(), Messages.RentalsListed);
        }

        public IDataResult<List<Rental>> GetByDate(DateTime rentDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate == rentDate).ToList());
        }

        public IResult IsCarRented(int carId)
        {
            IResult result = BusinessRules.Run(IsCarCanRent(carId));
            if (result != null)
            {
                return new ErrorResult("Araç belirtilen aralıkta uygun değil.");
            }
            return new SuccessResult("Belirtilen tarihte araç durumu müsait");
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            var result = _rentalDal.GetRentalDetails(c => c.CarId == carId);
            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }

        private IResult IsCarCanRent(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId).ToList().Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }


        public List<int> CalculateTotalPrice(DateTime rentDate, DateTime returnDate, int carId)
        {
            List<int> totalAmount = new List<int>();
            var dateDifference = (returnDate - rentDate).Days;
            //var datesOfDifference = dateDifference.Days;
            var dailyCarPrice = decimal.ToInt32(_carDal.Get(c => c.CarId == carId).DailyPrice);
            var totalPrice = dateDifference * dailyCarPrice;
            totalAmount.Add(dateDifference);
            totalAmount.Add(totalPrice);
            return totalAmount;
        }

        private IResult IsCarAvailableForSelectedDates(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.RentDate <= rental.ReturnDate).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

    }
}
