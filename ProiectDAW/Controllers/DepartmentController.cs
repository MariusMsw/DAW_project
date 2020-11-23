using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService DepartmentService)
        {
            this._departmentService = DepartmentService;
        }

        // GET: api/Department
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            IEnumerable<Department> Result = _departmentService.GetDepartments();
            if (Result == null)
            {
                return Ok(new List<Department>());
            }
            return Ok(Result);
        }

        // GET: api/Department/5
        [HttpGet("{DepartmentId}")]
        public ActionResult<Employee> GetDepartment(int DepartmentId)
        {
            Department Result = _departmentService.GetDepartment(DepartmentId);
            if (Result == null)
            {
                return NotFound(DepartmentId);
            }
            return Ok(Result);
        }

        // PUT: api/Department/5
        [HttpPut("{DepartmentId}")]
        public ActionResult<Department> UpdateDepartment(int DepartmentId, Department Department)
        {
            Department Result = _departmentService.UpdateDepartment(DepartmentId, Department);
            if (Result == null)
            {
                return NotFound(DepartmentId);
            }
            return Ok(Result);
        }

        // POST: api/Department
        [HttpPost]
        public ActionResult<Department> CreateDepartment(Department Department)
        {
            Department Result = _departmentService.CreateDepartment(Department);
            if (Result == null)
            {
                return Conflict(Department.Name);
            }
            return Ok(Department);
        }

        // DELETE: api/Department/5
        [HttpDelete("{DepartmentId}")]
        public ActionResult<bool> DeleteDepartment(int DepartmentId)
        {
            bool Result = _departmentService.DeleteDepartment(DepartmentId);
            if (Result)
            {
                return Ok();
            }
            return NotFound(DepartmentId);
        }
    }
}
