using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.IServices
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployees();

        public Employee GetEmployee(int id);

        public Employee CreateEmployee(Employee employee);

        public Employee UpdateEmployee(int employeeId, Employee employee);

        public bool DeleteEmployee(int id);
    }
}
