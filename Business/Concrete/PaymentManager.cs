using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            IResult result = BusinessRules.Run(CheckIfMoneyEnough(payment.Price));
            if (result != null)
            {
                return result;

            }
            _paymentDal.Add(payment);
            return new SuccessResult("Payment added");
        }
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult("payment updated");
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult("payment deleted");
        }

        private IResult CheckIfMoneyEnough(decimal price)
        {
            var result = _paymentDal.GetAll(p => p.Price >= price).ToList().Any();
            if (result)
            {
                return new ErrorResult("para yetersiz");
            }
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment> GetByPaymentId(int paymentId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.PaymentId == paymentId));
        }

        public IDataResult<Payment> GetDetailByUserId(int userId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.UserId == userId));
        }

    }
}
