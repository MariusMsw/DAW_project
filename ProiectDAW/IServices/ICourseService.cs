using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.IServices
{
   public interface ICourseService
    {
        public List<Course> GetCourses();

        public Course GetCourse(int id);

        public Course CreateCourse(Course Course);

        public Course UpdateCourse(int CourseId, Course Course);

        public bool DeleteCourse(int id);
    }
}
