using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOp)
        {
            _userOperationClaimDal.Add(userOp);
            return new SuccessResult();
        }

        public IResult Delete(UserOperationClaim userOp)
        {
            _userOperationClaimDal.Delete(userOp);
            return new SuccessResult();
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll().ToList());
        }

        public IDataResult<UserOperationClaim> GetById(int userOpId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(userOp => userOp.Id == userOpId));
        }

        public IDataResult<List<UserOperationClaimDetailDto>> GetUserOperationsByUserId(int userId)
        {
            var result = _userOperationClaimDal.GetUserOperationDetails(userOp => userOp.UserId == userId);
            return new SuccessDataResult<List<UserOperationClaimDetailDto>>(result);
        }

        public IDataResult<UserOperationClaimDetailDto> GetUserOperationDetail(int userOpId)
        {
            var result = _userOperationClaimDal.GetUserOperationDetail(userOp => userOp.Id == userOpId);
            return new SuccessDataResult<UserOperationClaimDetailDto>(result);
        }

        public IDataResult<List<UserOperationClaimDetailDto>> GetUserOperationDetails()
        {
            return new SuccessDataResult<List<UserOperationClaimDetailDto>>(_userOperationClaimDal.GetUserOperationDetails());
        }

        public IResult Update(UserOperationClaim userOp)
        {
            _userOperationClaimDal.Update(userOp);
            return new SuccessResult(Messages.UserOperationUpdated);

        }
    }
}
