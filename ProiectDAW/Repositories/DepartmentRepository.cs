using Microsoft.EntityFrameworkCore;
using ProiectDAW.Data;
using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(Context context) : base(context)
        {

        }

        public Department GetDepartmentByName(string name)
        {
            return _table.Where(x => x.Name == name).FirstOrDefault();
        }

        public Department GetDepartmentAllDetails(int DepartmentId)
        {
            return _table.Where(dep => dep.DepartmentId == DepartmentId)
                .Include(dep => dep.Employees)
                .ThenInclude(dep => dep.Laptop)
                .FirstOrDefault();
        }

        public List<Department> GetDepartmentsAllDetails()
        {
            return _table.Include(dep => dep.Employees)
                .ThenInclude(emp => emp.Laptop).ToList();
        }
    }
}
