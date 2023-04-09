using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Task = Entities.Concrete.Task;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTaskDal : EfEntityRepositoryBase<Task, EmployeeDatabaseContext>, ITaskDal
    {

    }
}
