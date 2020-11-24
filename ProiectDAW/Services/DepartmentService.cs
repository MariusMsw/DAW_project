using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository DepartmentRepository)
        {
            this._departmentRepository = DepartmentRepository;
        }

        public Department CreateDepartment(Department Department)
        {
            if (_departmentRepository.GetDepartmentByName(Department.Name) != null)
            {
                return null;
            }

            _departmentRepository.Create(Department);
            _departmentRepository.SaveChanges();
            return Department;
        }

        public bool DeleteDepartment(int DepartmentId)
        {
            Department Department = _departmentRepository.FindById(DepartmentId);
            if (Department == null)
            {
                return false;
            }

            _departmentRepository.Delete(Department);
            _departmentRepository.SaveChanges();

            return true;
        }

        public Department GetDepartment(int DepartmentId)
        {
            return _departmentRepository.GetDepartmentAllDetails(DepartmentId);
        }

        public List<Department> GetDepartments()
        {
            return _departmentRepository.GetDepartmentsAllDetails();
        }

        public Department UpdateDepartment(int DepartmentId, Department Department)
        {
            Department ExistingDepartment = _departmentRepository.FindById(DepartmentId);
            if (ExistingDepartment == null)
            {
                return null;
            }

            ExistingDepartment.Employees = Department.Employees;
            ExistingDepartment.Name = Department.Name;

            _departmentRepository.Update(ExistingDepartment);
            _departmentRepository.SaveChanges();

            return ExistingDepartment;
        }
    }
}
