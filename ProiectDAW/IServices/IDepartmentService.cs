using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.IServices
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();

        public Department GetDepartment(int id);

        public Department CreateDepartment(Department Department);

        public Department UpdateDepartment(int DepartmentId, Department Department);

        public bool DeleteDepartment(int id);
    }
}
