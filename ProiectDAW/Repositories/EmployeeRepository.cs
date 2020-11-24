using Microsoft.EntityFrameworkCore;
using ProiectDAW.Data;
using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProiectDAW.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Context context) : base(context)
        {
            
        }

        public Employee GetEmployeeByMail(string mail)
        {
            return _table.Where(x => x.Mail == mail).FirstOrDefault();
        }

        public Employee GetEmployeeAllDetails(int EmployeeId)
        {
            return _table.Where(emp => emp.EmployeeId == EmployeeId)
                .Include(emp => emp.Department)
                .Include(emp => emp.Laptop)
                .Include(emp => emp.EmployeeCourses)
                .ThenInclude(ec => ec.Course).FirstOrDefault();
        }

        public List<Employee> GetEmployeesAllDetails()
        {
            return _table
                .Include(emp => emp.Department)
                .Include(emp => emp.Laptop)
                .Include(emp => emp.EmployeeCourses)
                .ThenInclude(ec => ec.Course)
                .ToList();
        }
    }
}
