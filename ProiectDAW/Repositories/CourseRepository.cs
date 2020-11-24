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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(Context context) : base(context)
        {
            
        }

        public Course GetCourseByName(string name)
        {
            return _table.Where(x => x.Name == name).FirstOrDefault();
        }

        public Course GetCourseAllDetails(int CourseId)
        {
            return _table.Where(course => course.CourseId == CourseId)
                .Include(emp => emp.EmployeeCourses)
                .ThenInclude(emp => emp.Employee).FirstOrDefault();
        }

        public List<Course> GetCoursesAllDetails()
        {
            return _table.Include(emp => emp.EmployeeCourses).ThenInclude(emp => emp.Employee).ToList();
        }
    }
}
