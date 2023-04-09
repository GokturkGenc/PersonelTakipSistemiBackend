using Castle.Core.Logging;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, EmployeeDatabaseContext>, IEmployeeDal
    {
        public EmployeeDetailDto GetEmployeeDetail(Expression<Func<Employee, bool>> filter)
        {
            using (var context = new EmployeeDatabaseContext())
            {
                var result = from employee in context.Employees.Where(filter)
                             join task in context.Tasks on employee.TaskId equals task.TaskId
                             join unit in context.Units on employee.UnitId equals unit.UnitId
                             join branch in context.Branches on employee.BranchId equals branch.BranchId
                             select new EmployeeDetailDto
                             {
                                 EmployeeId = employee.EmployeeId,
                                 TaskId = task.TaskId,
                                 UnitId = unit.UnitId,
                                 TaskName = task.TaskName,
                                 UnitName = unit.UnitName,
                                 ContactNumbers = employee.ContactNumbers,
                                 Adresses = employee.Adresses,
                                 BirthDate = employee.BirthDate,
                                 BirthPlace = employee.BirthPlace,
                                 BranchCityName = branch.BranchCityName,
                                 BranchId = branch.BranchId,
                                 DateOfEntry = employee.DateOfEntry,
                                 EducationStatus = employee.EducationStatus,
                                 FirstName = employee.FirstName,
                                 LastName = employee.LastName,
                                 LeavingDate = employee.LeavingDate,
                                 NationalId = employee.NationalId
                             };
                return result.SingleOrDefault();

            }
        }

        public List<EmployeeDetailDto> GetEmployeeDetails(Expression<Func<Employee, bool>> filter = null)
        {
            using (var context = new EmployeeDatabaseContext())
            {
                var result = from employee in filter == null ? context.Employees : context.Employees.Where(filter)
                             join task in context.Tasks on employee.TaskId equals task.TaskId
                             join unit in context.Units on employee.UnitId equals unit.UnitId
                             join branch in context.Branches on employee.BranchId equals branch.BranchId
                             select new EmployeeDetailDto
                             {
                                 EmployeeId = employee.EmployeeId,
                                 TaskId = task.TaskId,
                                 UnitId = unit.UnitId,
                                 TaskName = task.TaskName,
                                 UnitName = unit.UnitName,
                                 ContactNumbers = employee.ContactNumbers,
                                 Adresses = employee.Adresses,
                                 BirthDate = employee.BirthDate,
                                 BirthPlace = employee.BirthPlace,
                                 BranchCityName = branch.BranchCityName,
                                 BranchId = branch.BranchId,
                                 DateOfEntry = employee.DateOfEntry,
                                 EducationStatus = employee.EducationStatus,
                                 FirstName = employee.FirstName,
                                 LastName = employee.LastName,
                                 LeavingDate = employee.LeavingDate,
                                 NationalId = employee.NationalId
                             };
                return result.ToList();
            }
        }

        public List<EmployeeDetailDto> GetEmployeeDetailsByTask(int taskId)
        {
            using (var context = new EmployeeDatabaseContext())
            {
                var result = from employee in context.Employees
                             join task in context.Tasks on employee.TaskId equals task.TaskId
                             join unit in context.Units on employee.UnitId equals unit.UnitId
                             join branch in context.Branches on employee.BranchId equals branch.BranchId
                             where task.TaskId == taskId
                             select new EmployeeDetailDto
                             {
                                 EmployeeId = employee.EmployeeId,
                                 TaskId = task.TaskId,
                                 UnitId = unit.UnitId,
                                 TaskName = task.TaskName,
                                 UnitName = unit.UnitName,
                                 ContactNumbers = employee.ContactNumbers,
                                 Adresses = employee.Adresses,
                                 BirthDate = employee.BirthDate,
                                 BirthPlace = employee.BirthPlace,
                                 BranchCityName = branch.BranchCityName,
                                 BranchId = branch.BranchId,
                                 DateOfEntry = employee.DateOfEntry,
                                 EducationStatus = employee.EducationStatus,
                                 FirstName = employee.FirstName,
                                 LastName = employee.LastName,
                                 LeavingDate = employee.LeavingDate,
                                 NationalId = employee.NationalId
                             };
                return result.ToList();
            }
        }

        public List<EmployeeDetailDto> GetEmployeeDetailsByBranch(int branchId)
        {
            using (var context = new EmployeeDatabaseContext())
            {
                var result = from employee in context.Employees
                             join task in context.Tasks on employee.TaskId equals task.TaskId
                             join unit in context.Units on employee.UnitId equals unit.UnitId
                             join branch in context.Branches on employee.BranchId equals branch.BranchId
                             where branch.BranchId == branchId
                             select new EmployeeDetailDto
                             {
                                 EmployeeId = employee.EmployeeId,
                                 TaskId = task.TaskId,
                                 UnitId = unit.UnitId,
                                 TaskName = task.TaskName,
                                 UnitName = unit.UnitName,
                                 ContactNumbers = employee.ContactNumbers,
                                 Adresses = employee.Adresses,
                                 BirthDate = employee.BirthDate,
                                 BirthPlace = employee.BirthPlace,
                                 BranchCityName = branch.BranchCityName,
                                 BranchId = branch.BranchId,
                                 DateOfEntry = employee.DateOfEntry,
                                 EducationStatus = employee.EducationStatus,
                                 FirstName = employee.FirstName,
                                 LastName = employee.LastName,
                                 LeavingDate = employee.LeavingDate,
                                 NationalId = employee.NationalId
                             };
                return result.ToList();
            }
        }

        public List<EmployeeDetailDto> GetEmployeeDetailsByUnit(int unitId)
        {
            using (var context = new EmployeeDatabaseContext())
            {
                var result = from employee in context.Employees
                             join task in context.Tasks on employee.TaskId equals task.TaskId
                             join unit in context.Units on employee.UnitId equals unit.UnitId
                             join branch in context.Branches on employee.BranchId equals branch.BranchId
                             where unit.UnitId == unitId
                             select new EmployeeDetailDto
                             {
                                 EmployeeId = employee.EmployeeId,
                                 TaskId = task.TaskId,
                                 UnitId = unit.UnitId,
                                 TaskName = task.TaskName,
                                 UnitName = unit.UnitName,
                                 ContactNumbers = employee.ContactNumbers,
                                 Adresses = employee.Adresses,
                                 BirthDate = employee.BirthDate,
                                 BirthPlace = employee.BirthPlace,
                                 BranchCityName = branch.BranchCityName,
                                 BranchId = branch.BranchId,
                                 DateOfEntry = employee.DateOfEntry,
                                 EducationStatus = employee.EducationStatus,
                                 FirstName = employee.FirstName,
                                 LastName = employee.LastName,
                                 LeavingDate = employee.LeavingDate,
                                 NationalId = employee.NationalId
                             };
                return result.ToList();
            }
        }

        public List<EmployeeDetailDto> GetEmployeeDetailsByUnitAndTask(int unitId, int taskId)
        {
            using (var context = new EmployeeDatabaseContext())
            {
                var result = from employee in context.Employees
                             join task in context.Tasks on employee.TaskId equals task.TaskId
                             join unit in context.Units on employee.UnitId equals unit.UnitId
                             join branch in context.Branches on employee.BranchId equals branch.BranchId
                             where task.TaskId == taskId & unit.UnitId == unitId
                             select new EmployeeDetailDto
                             {
                                 EmployeeId = employee.EmployeeId,
                                 TaskId = task.TaskId,
                                 UnitId = unit.UnitId,
                                 TaskName = task.TaskName,
                                 UnitName = unit.UnitName,
                                 ContactNumbers = employee.ContactNumbers,
                                 Adresses = employee.Adresses,
                                 BirthDate = employee.BirthDate,
                                 BirthPlace = employee.BirthPlace,
                                 BranchCityName = branch.BranchCityName,
                                 BranchId = branch.BranchId,
                                 DateOfEntry = employee.DateOfEntry,
                                 EducationStatus = employee.EducationStatus,
                                 FirstName = employee.FirstName,
                                 LastName = employee.LastName,
                                 LeavingDate = employee.LeavingDate,
                                 NationalId = employee.NationalId
                             };
                return result.ToList();
            }
        }

        public List<EmployeeDetailDto> GetStillWorkers()
        {
            using (var context = new EmployeeDatabaseContext())
            {
                var result = from employee in context.Employees
                             join task in context.Tasks on employee.TaskId equals task.TaskId
                             join unit in context.Units on employee.UnitId equals unit.UnitId
                             join branch in context.Branches on employee.BranchId equals branch.BranchId
                             where employee.LeavingDate != null
                             select new EmployeeDetailDto
                             {
                                 EmployeeId = employee.EmployeeId,
                                 TaskId = task.TaskId,
                                 UnitId = unit.UnitId,
                                 TaskName = task.TaskName,
                                 UnitName = unit.UnitName,
                                 ContactNumbers = employee.ContactNumbers,
                                 Adresses = employee.Adresses,
                                 BirthDate = employee.BirthDate,
                                 BirthPlace = employee.BirthPlace,
                                 BranchCityName = branch.BranchCityName,
                                 BranchId = branch.BranchId,
                                 DateOfEntry = employee.DateOfEntry,
                                 EducationStatus = employee.EducationStatus,
                                 FirstName = employee.FirstName,
                                 LastName = employee.LastName,
                                 LeavingDate = employee.LeavingDate,
                                 NationalId = employee.NationalId
                             };
                return result.ToList();
            }
        }
    }

}


