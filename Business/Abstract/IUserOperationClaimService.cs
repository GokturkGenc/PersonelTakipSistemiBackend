using Core.Entities.Concrete;
using Core.Entities.DTOs;
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
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<List<UserOperationClaimDetailDto>> GetUserOperationDetails();
        IDataResult<UserOperationClaimDetailDto> GetUserOperationDetail(int userOpId);
        IDataResult<List<UserOperationClaimDetailDto>> GetUserOperationsByUserId(int userId);

        IDataResult<UserOperationClaim> GetById(int userOpId);
        IResult Add(UserOperationClaim userOp);
        IResult Delete(UserOperationClaim userOp);
        IResult Update(UserOperationClaim userOp);
    }
}
