using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //List<CarDetailDto> GetCarDetails();
        //List<CarDetailDto> GetCarsByBrandId(int brandId);
        //List<CarDetailDto> GetCarsByColorId(int colorId);
        //List<CarDetailDto> GetCarsByCarId(int carId);

        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetail(Expression<Func<Car, bool>> filter);
    }
}
