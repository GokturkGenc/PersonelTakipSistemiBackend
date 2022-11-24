using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        //IResult IsCarAvailableForSelectedDates(Rental rental);
        IResult IsCarRented(int carId);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetByDate(DateTime rentDate);

        IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId);

        IDataResult<Rental> GetById(int id);
        List<int> CalculateTotalPrice(DateTime rentDate, DateTime returnDate, int carId);
    }
}
