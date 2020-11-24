using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.IServices;
using System.Collections.Generic;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            IEnumerable<Employee> Result =  _employeeService.GetEmployees();
            if (Result == null)
            {
                return Ok(new List<Employee>());
            }
            return Ok(Result);
        }

        // GET: api/Employee/5
        [HttpGet("{EmployeeId}")]
        public ActionResult<Employee> GetEmployee(int EmployeeId)
        {
            Employee Result = _employeeService.GetEmployee(EmployeeId);
            if (Result == null)
            {
                return NotFound(EmployeeId);
            }
            return Ok(Result);
        }

        // PUT: api/Employee/5
        [HttpPut("{EmployeeId}")]
        public ActionResult<Employee> UpdateEmployee(int EmployeeId, Employee Employee)
        {
           Employee Result =  _employeeService.UpdateEmployee(EmployeeId, Employee);
           if (Result == null)
            {
                return NotFound(EmployeeId);
            }
            return Ok(Result);
        }

        // POST: api/Employee
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee Employee)
        {
            Employee Result = _employeeService.CreateEmployee(Employee);
            if (Result == null)
            {
                return Conflict(Employee.Mail);
            }
            return Ok(Employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{EmployeeId}")]
        public ActionResult<bool> DeleteEmployee(int EmployeeId)
        {
            bool Result = _employeeService.DeleteEmployee(EmployeeId);
            if (Result)
            {
                return Ok();
            }
            return NotFound(EmployeeId);
        }

        // Post: api/Employee/assign-department/1/2
        [HttpPost("assign-department/{EmployeeId}/{DepartmentId}")]
        public ActionResult<bool> AssignDepartmentToEmployee(int EmployeeId, int DepartmentId)
        {
            bool Result = _employeeService.AssignDepartmentToEmployee(EmployeeId, DepartmentId);
            if (Result)
            {
                return Ok();
            }
            return NotFound(EmployeeId);
        }

        // Post: api/Employee/assign-laptop/1/2
        [HttpPost("assign-laptop/{EmployeeId}/{LaptopId}")]
        public ActionResult<bool> AssignLaptopToEmployee(int EmployeeId, int LaptopId)
        {
            bool Result = _employeeService.AssignLaptopToEmployee(EmployeeId, LaptopId);
            if (Result)
            {
                return Ok();
            }
            return NotFound(EmployeeId);
        }

        // Post: api/Employee/enroll/1/2
        [HttpPost("enroll/{EmployeeId}/{CourseId}")]
        public ActionResult<bool> EnrollEmployeeToCourse(int EmployeeId, int CourseId)
        {
            bool Result = _employeeService.EnrollEmployeeToCourse(EmployeeId, CourseId);
            if (Result)
            {
                return Ok();
            }
            return NotFound(EmployeeId);
        }
    }
}

