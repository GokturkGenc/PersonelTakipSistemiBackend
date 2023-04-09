using Core.DataAccess;
using Task = Entities.Concrete.Task;

namespace DataAccess.Abstract
{
    public interface ITaskDal : IEntityRepository<Task>
    {

    }
}
