using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results;
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
    public interface IUserDal : IEntityRepository<User>
    {
        List<User> GetUserDetails(Expression<Func<User, bool>> filter = null);
        User GetUserDetail(Expression<Func<User, bool>> filter);
        List<OperationClaim> GetClaims(User user);
        List<User> GetUserByName(string firstName,string lastName);
    }
}
