using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public Department GetDepartmentByName(string name);

        public Department GetDepartmentAllDetails(int DepartmentId);

        public List<Department> GetDepartmentsAllDetails();
    }
}
