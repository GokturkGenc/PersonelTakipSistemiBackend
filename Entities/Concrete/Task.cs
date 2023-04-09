using Core.Entities;

namespace Entities.Concrete
{
    public class Task : IEntity
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

    }
}
