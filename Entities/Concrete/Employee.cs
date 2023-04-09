using Core.Entities;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Adresses { get; set; }
        public string ContactNumbers { get; set; }
        public string EducationStatus { get; set; }
        public DateTime DateOfEntry { get; set; }
        public DateTime? LeavingDate { get; set; }
        public int UnitId { get; set; }
        public int TaskId { get; set; }
        public int BranchId { get; set; }


    }
}
