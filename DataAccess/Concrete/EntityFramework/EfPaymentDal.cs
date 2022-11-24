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
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, CarDatabaseContext>, IPaymentDal
    {
        public Payment GetPaymentDetail(Expression<Func<Payment, bool>> filter)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from payment in context.Payments.Where(filter)
                             join user in context.Users on payment.UserId equals user.UserId
                             select new Payment
                             {
                                 UserId = user.UserId,
                                 CreditCardNumber = payment.CreditCardNumber,
                                 Price = payment.Price,
                                 SecurityNumber = payment.SecurityNumber,
                                 ExpirationDate = payment.ExpirationDate,
                             };
                return result.SingleOrDefault();

            }
        }

        public List<Payment> GetPaymentDetails(Expression<Func<Payment, bool>> filter = null)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from payment in context.Payments.Where(filter)
                             join user in context.Users on payment.UserId equals user.UserId
                             select new Payment
                             {
                                 UserId = user.UserId,
                                 CreditCardNumber = payment.CreditCardNumber,
                                 Price = payment.Price,
                                 SecurityNumber = payment.SecurityNumber,
                                 ExpirationDate = payment.ExpirationDate,
                             };
                return result.ToList();
            }
        }
    }
}
