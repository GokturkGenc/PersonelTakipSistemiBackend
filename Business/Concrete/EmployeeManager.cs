using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {

        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }


        public IResult Add(Employee employee)
        {
            IResult result = BusinessRules.Run(CheckIfNationalIdExists(employee.NationalId));

            if (result != null)
            {
                return new ErrorResult(Messages.NationalIdAlreadyExists);

            }
            _employeeDal.Add(employee);
            return new SuccessResult();

        }


        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult();
        }

        
        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.EmployeeUpdated);
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll().ToList());
        }


        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<EmployeeDetailDto>> GetEmployeesByTaskId(int taskId)
        {
            var result = _employeeDal.GetEmployeeDetails(c => c.TaskId == taskId);
            return new SuccessDataResult<List<EmployeeDetailDto>>(result);
        }

        public IDataResult<List<EmployeeDetailDto>> GetEmployeesByBranchId(int branchId)
        {
            var result = _employeeDal.GetEmployeeDetails(c => c.BranchId == branchId);
            return new SuccessDataResult<List<EmployeeDetailDto>>(result);
        }


        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<EmployeeDetailDto>> GetStillWorkers()
        {
            var result = _employeeDal.GetEmployeeDetails(c => c.LeavingDate == null);
            return new SuccessDataResult<List<EmployeeDetailDto>>(result);
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<EmployeeDetailDto>> GetEmployeesByUnitId(int unitId)
        {
            var result = _employeeDal.GetEmployeeDetails(c => c.UnitId == unitId);
            return new SuccessDataResult<List<EmployeeDetailDto>>(result);
        }
        public IDataResult<List<EmployeeDetailDto>> GetEmployeesByUnitAndTask(int unitId, int taskId)
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(_employeeDal.GetEmployeeDetailsByUnitAndTask(unitId, taskId));
        }


        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<Employee> GetById(int employeeId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(c => c.EmployeeId == employeeId));
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails()
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(_employeeDal.GetEmployeeDetails());
        }


        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<EmployeeDetailDto> GetEmployeeDetail(int employeeId)
        {
            var result = _employeeDal.GetEmployeeDetail(c => c.EmployeeId == employeeId);
            return new SuccessDataResult<EmployeeDetailDto>(result);
        }

        private IResult CheckIfNationalIdExists(string nationalId)
        {
            var result = _employeeDal.GetAll(c => c.NationalId == nationalId).ToList().Any();
            if (result)
            {
                return new ErrorResult(Messages.NationalIdAlreadyExists);
            }
            return new SuccessResult();
        }


    }
}
