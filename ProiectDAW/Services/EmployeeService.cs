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
        private readonly ICourseRepository _courseRepository;
        private readonly IEmployeeCourseRepository _employeeCourseRepository;


        public EmployeeService(IEmployeeRepository EmployeeRepository,
                                IDepartmentRepository DepartmentRepository,
                                ILaptopRepository LaptopRepository,
                                ICourseRepository CourseRepository,
                                IEmployeeCourseRepository EmployeeCourseRepository)
        {
            this._employeeRepository = EmployeeRepository;
            this._departmentRepository = DepartmentRepository;
            this._laptopRepository = LaptopRepository;
            this._courseRepository = CourseRepository;
            this._employeeCourseRepository = EmployeeCourseRepository;
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

            ExistingEmployee.DepartmentId = employee.DepartmentId;
            ExistingEmployee.EmployeeCourses = employee.EmployeeCourses;
            ExistingEmployee.LaptopId = employee.LaptopId;
            ExistingEmployee.Mail = employee.Mail;
            ExistingEmployee.Name = employee.Name;
            ExistingEmployee.Salary = employee.Salary;

            _employeeRepository.Update(ExistingEmployee);
            _employeeRepository.SaveChanges();

            return ExistingEmployee;
        }

        public bool AssignDepartmentToEmployee(int employeeId, int departmentId)
        {
            Employee ExistingEmployee = _employeeRepository.FindById(employeeId);
            Department ExistingDepartment = _departmentRepository.FindById(departmentId);
            if (ExistingEmployee == null || ExistingDepartment == null)
            {
                return false;
            }
            ExistingEmployee.DepartmentId = departmentId;
            _employeeRepository.Update(ExistingEmployee);
            _employeeRepository.SaveChanges();

            ExistingDepartment.Employees.Add(ExistingEmployee);
            _departmentRepository.Update(ExistingDepartment);
            _departmentRepository.SaveChanges();
            return true;
        }
        public bool AssignLaptopToEmployee(int employeeId, int laptopId)
        {
            Employee ExistingEmployee = _employeeRepository.FindById(employeeId);
            Laptop ExistingLaptop = _laptopRepository.FindById(laptopId);

            if (ExistingEmployee == null || ExistingLaptop == null)
            {
                return false;
            }
            ExistingEmployee.LaptopId = laptopId;
            _employeeRepository.Update(ExistingEmployee);
            _employeeRepository.SaveChanges();

            ExistingLaptop.Employee = ExistingEmployee;
            _laptopRepository.Update(ExistingLaptop);
            _laptopRepository.SaveChanges();
            return true;
        }

        public bool EnrollEmployeeToCourse(int employeeId, int courseId)
        {
            Employee ExistingEmployee = _employeeRepository.FindById(employeeId);
            Course ExistingCourse = _courseRepository.FindById(courseId);

            if (ExistingEmployee == null || ExistingCourse == null)
            {
                return false;
            }

            EmployeeCourse employeeCourse = new EmployeeCourse
            {
                CourseId = courseId,
                EmployeeId = employeeId
            };

            _employeeCourseRepository.Create(employeeCourse);
            _employeeCourseRepository.SaveChanges();

            ExistingEmployee.EmployeeCourses.Add(employeeCourse);
            _employeeRepository.Update(ExistingEmployee);
            _employeeRepository.SaveChanges();

            ExistingCourse.EmployeeCourses.Add(employeeCourse);
            _courseRepository.Update(ExistingCourse);
            _courseRepository.SaveChanges();
            return true;
        }
    }
}
