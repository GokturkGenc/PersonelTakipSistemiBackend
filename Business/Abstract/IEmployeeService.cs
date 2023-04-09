using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetAll();
        IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails();
        IDataResult<EmployeeDetailDto> GetEmployeeDetail(int employeeId);
        IDataResult<List<EmployeeDetailDto>> GetEmployeesByUnitId(int unitId);
        IDataResult<List<EmployeeDetailDto>> GetEmployeesByBranchId(int branchId);
        IDataResult<List<EmployeeDetailDto>> GetEmployeesByTaskId(int taskId);
        IDataResult<List<EmployeeDetailDto>> GetStillWorkers();
        //
        IDataResult<List<EmployeeDetailDto>> GetEmployeesByUnitAndTask(int unitId, int taskId);
        //
        IDataResult<Employee> GetById(int employeeId);
        IResult Add(Employee employee);
        IResult Delete(Employee employee);
        IResult Update(Employee employee);
    }
}
