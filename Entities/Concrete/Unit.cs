using Core.Entities;

namespace Entities.Concrete
{
    public class Unit : IEntity
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
    }
}
