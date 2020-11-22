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

        // GET: api/Employees
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

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int EmployeeId)
        {
            Employee Result = _employeeService.GetEmployee(EmployeeId);
            if (Result == null)
            {
                return NotFound(EmployeeId);
            }
            return Ok(Result);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int EmployeeId, Employee employee)
        {
           Employee Result =  _employeeService.UpdateEmployee(EmployeeId, employee);
           if (Result == null)
            {
                return NotFound(EmployeeId);
            }
            return Ok(Result);
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            Employee Result = _employeeService.CreateEmployee(employee);
            if (Result == null)
            {
                return Conflict(employee.Mail);
            }
            return Ok(employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteEmployee(int EmployeeId)
        {
            bool Result = _employeeService.DeleteEmployee(EmployeeId);
            if (Result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

