using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getworkers")]
        public IActionResult GetStillWorkers()
        {
            var result = _employeeService.GetStillWorkers();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbytask")]
        public IActionResult GetByTaskId(int taskId)
        {
            var result = _employeeService.GetEmployeesByTaskId(taskId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyunit")]
        public IActionResult GetByUnit(int unitId)
        {
            var result = _employeeService.GetEmployeesByUnitId(unitId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybranch")]
        public IActionResult GetByBranch(int branchId)
        {
            var result = _employeeService.GetEmployeesByBranchId(branchId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getemployeedetails")]
        public IActionResult GetEmployeeDetails()
        {
            var result = _employeeService.GetEmployeeDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getemployeedetail")]
        public IActionResult GetEmployeeDetail(int employeeId)
        {
            var result = _employeeService.GetEmployeeDetail(employeeId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Employee employee)
        {
            var result = _employeeService.Add(employee);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Employee employee)
        {
            var result = _employeeService.Delete(employee);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Employee employee)
        {
            var result = _employeeService.Update(employee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getemployeesbyunitandtask")]
        public IActionResult GetEmployeesByUnitAndTask(int unitId, int taskId)
        {

            var result = _employeeService.GetEmployeesByUnitAndTask(unitId, taskId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
