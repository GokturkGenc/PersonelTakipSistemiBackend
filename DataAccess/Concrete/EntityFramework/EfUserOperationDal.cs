using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
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
    public class EfUserOperationDal : EfEntityRepositoryBase<UserOperationClaim, CarDatabaseContext>, IUserOperationClaimDal
    {
        public UserOperationClaimDetailDto GetUserOperationDetail(Expression<Func<UserOperationClaim, bool>> filter)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from userOp in context.UserOperationClaims.Where(filter)
                             join user in context.Users on userOp.UserId equals user.UserId
                             join operation in context.OperationClaims on userOp.OperationClaimId equals operation.Id
                             select new UserOperationClaimDetailDto
                             {
                                 UserId = user.UserId,
                                 Id = userOp.Id,
                                 OperationClaimId = operation.Id,
                                 OperationClaimName = operation.Name,
                             };
                return result.SingleOrDefault();

            }
        }

        public List<UserOperationClaimDetailDto> GetUserOperationDetails(Expression<Func<UserOperationClaim, bool>> filter = null)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from userOp in filter == null ? context.UserOperationClaims :
                             context.UserOperationClaims.Where(filter)
                             join user in context.Users on userOp.UserId equals user.UserId
                             join operation in context.OperationClaims on userOp.OperationClaimId equals operation.Id
                             select new UserOperationClaimDetailDto
                             {
                                 UserId = user.UserId,
                                 Id = userOp.Id,
                                 OperationClaimId = operation.Id,
                                 OperationClaimName = operation.Name,
                             };
                return result.ToList();
            }
        }
    }
}
