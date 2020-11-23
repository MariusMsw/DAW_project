using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.IServices;
using System.Collections.Generic;

namespace ProiectDAW.Controllers
{   //TODO
    /*
     * asign employee to department
     * assign laptop to employee
     * enroll employee in course
     */
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

        // PUT: api/Employee/5
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteEmployee(int EmployeeId)
        {
            bool Result = _employeeService.DeleteEmployee(EmployeeId);
            if (Result)
            {
                return Ok();
            }
            return NotFound(EmployeeId);
        }

        //TODO
        /*
         * asign employee to department
         * assign laptop to employee
         * enroll employee in course
         */
    }
}

