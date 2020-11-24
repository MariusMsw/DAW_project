using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILaptopRepository _laptopRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository,
                                IDepartmentRepository DepartmentRepository,
                                ILaptopRepository LaptopRepository)
        {
            this._employeeRepository = EmployeeRepository;
            this._departmentRepository = DepartmentRepository;
            this._laptopRepository = LaptopRepository;
        }

        public Employee CreateEmployee(Employee employee)
        {
            if (_employeeRepository.GetEmployeeByMail(employee.Mail) != null)
            {
                return null;
            }

            employee = _employeeRepository.Create(employee);
            _employeeRepository.SaveChanges();

            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            Employee employee = _employeeRepository.FindById(id);
            if (employee == null)
            {
                return false;
            }

            _employeeRepository.Delete(employee);
            _employeeRepository.SaveChanges();

            return true;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployeeAllDetails(id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployeesAllDetails();
        }

        public Employee UpdateEmployee(int EmployeeId, Employee employee)
        {
            Employee ExistingEmployee = _employeeRepository.FindById(EmployeeId);
            if (ExistingEmployee == null)
            {
                return null;
            }

            ExistingEmployee.Department = employee.Department;
            ExistingEmployee.DepartmentId = employee.DepartmentId;
            ExistingEmployee.EmployeeCourses = employee.EmployeeCourses;
            ExistingEmployee.Laptop = employee.Laptop;
            ExistingEmployee.LaptopId = employee.LaptopId;
            ExistingEmployee.Mail = employee.Mail;
            ExistingEmployee.Name = employee.Name;
            ExistingEmployee.Salary = employee.Salary;

            _employeeRepository.Update(ExistingEmployee);
            _employeeRepository.SaveChanges();

            return ExistingEmployee;
        }
    }
}
