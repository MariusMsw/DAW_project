using ProiectDAW.Entities;
using ProiectDAW.Interfaces;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository CourseRepository)
        {
            this._courseRepository = CourseRepository;
        }

        public Course CreateCourse(Course Course)
        {
            if (_courseRepository.GetCourseByName(Course.Name) != null)
            {
                return null;
            }

            _courseRepository.Create(Course);
            _courseRepository.SaveChanges();
            return Course;
        }

        public bool DeleteCourse(int CourseId)
        {
            Course Course = _courseRepository.FindById(CourseId);
            if (Course == null)
            {
                return false;
            }

            _courseRepository.Delete(Course);
            _courseRepository.SaveChanges();

            return true;
        }

        public Course GetCourse(int CourseId)
        {
            return _courseRepository.GetCourseAllDetails(CourseId);
        }

        public List<Course> GetCourses()
        {
            return _courseRepository.GetCoursesAllDetails();
        }

        public Course UpdateCourse(int CourseId, Course Course)
        {
            Course ExistingCourse = _courseRepository.FindById(CourseId);
            if (ExistingCourse == null)
            {
                return null;
            }

            ExistingCourse.EmployeeCourses = Course.EmployeeCourses;
            ExistingCourse.EndDate = Course.EndDate;
            ExistingCourse.StartDate = Course.StartDate;
            ExistingCourse.Name = Course.Name;

            _courseRepository.Update(ExistingCourse);
            _courseRepository.SaveChanges();

            return ExistingCourse;
        }
    }
}
