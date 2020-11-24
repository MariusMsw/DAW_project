using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public Employee GetEmployeeByMail(string mail);

        public Employee GetEmployeeAllDetails(int EmployeeId);

        public List<Employee> GetEmployeesAllDetails();
    }
}
