using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        List<EmployeeDetailDto> GetEmployeeDetails(Expression<Func<Employee, bool>> filter = null);
        EmployeeDetailDto GetEmployeeDetail(Expression<Func<Employee, bool>> filter);
        List<EmployeeDetailDto> GetEmployeeDetailsByUnitAndTask(int unitId, int taskId);
        List<EmployeeDetailDto> GetEmployeeDetailsByUnit(int unitId);
        List<EmployeeDetailDto> GetEmployeeDetailsByTask(int taskId);
        List<EmployeeDetailDto> GetEmployeeDetailsByBranch(int branchId);
        List<EmployeeDetailDto> GetStillWorkers();
        //List<EmployeeDetailDto> GetStillWorkersEmployees(Expression<Func<Employee, bool>> filter = null);

    }
}
