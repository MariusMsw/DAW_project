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
    public class EmployeeCourseRepository : GenericRepository<EmployeeCourse>, IEmployeeCourseRepository
    {
        public EmployeeCourseRepository(Context context) : base(context)
        {
            
        }
        public EmployeeCourse GetEmployeeCourseAllDetails(int EmployeeCourseId)
        {
            return _table.Where(ec => ec.EmployeeCourseId == EmployeeCourseId)
                .Include(emp => emp.Employee)
                .Include(course => course.Course)
                .FirstOrDefault();
        }

        public List<EmployeeCourse> GetEmployeeCourseAllDetails()
        {
            return _table.Include(ec => ec.Employee)
                .Include(ec => ec.Course)
                .ToList();
        }
    }
}
