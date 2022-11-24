using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<Payment>
    {
        List<Payment> GetPaymentDetails(Expression<Func<Payment, bool>> filter = null);
        Payment GetPaymentDetail(Expression<Func<Payment, bool>> filter);
    }
}
