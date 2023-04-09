using Core.Entities;

namespace Entities.Concrete
{
    public class Branch : IEntity
    {
        public int BranchId { get; set; }
        public string BranchCityName { get; set; }
    }
}
