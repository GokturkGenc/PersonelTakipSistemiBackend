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
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResult Add(OperationClaim operation)
        {
            IResult result = BusinessRules.Run(CheckIfOperationNameExists(operation.Name));

            if (result != null)
            {
                return result;

            }
            _operationClaimDal.Add(operation);
            return new SuccessResult(Messages.OperationAddded);
        }

        public IResult Delete(OperationClaim operation)
        {
            _operationClaimDal.Delete(operation);
            return new SuccessResult();
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll().ToList(), Messages.OperationsListed);
        }

        public IDataResult<OperationClaim> GetById(int operationId)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(op => op.Id == operationId));
        }

        public IResult Update(OperationClaim operation)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfOperationNameExists(string operationName)
        {
            var result = _operationClaimDal.GetAll(op => op.Name == operationName).ToList().Any();
            if (result)
            {
                return new ErrorResult(Messages.OperationNameExist);
            }
            return new SuccessResult();
        }
    }
}
