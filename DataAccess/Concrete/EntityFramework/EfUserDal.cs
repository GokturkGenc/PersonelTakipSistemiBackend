using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfUserDal : EfEntityRepositoryBase<User, CarDatabaseContext>, IUserDal
    {
        public User GetUserDetail(Expression<Func<User, bool>> filter)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from user in context.Users.Where(filter)
                             select new User
                             {
                                 UserId = user.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PasswordHash = user.PasswordHash,
                                 PasswordSalt = user.PasswordSalt,
                                 Status = user.Status
                             };
                return result.SingleOrDefault();

            }
        }

        public List<User> GetUserDetails(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from user in filter == null ? context.Users : context.Users.Where(filter)
                             select new User
                             {
                                 UserId = user.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PasswordHash = user.PasswordHash,
                                 PasswordSalt = user.PasswordSalt,
                                 Status = user.Status
                             };
                return result.ToList();
            }
        }

        public List<User> GetUserByName(string firstName, string lastName)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from user in context.Users
                             select new User
                             {
                                 UserId = user.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PasswordHash = user.PasswordHash,
                                 PasswordSalt = user.PasswordSalt,
                                 Status = user.Status
                             };
                return result.ToList();
            }
        }
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarDatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
