using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.Entities;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        // GET: api/Course
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            IEnumerable<Course> Result = _courseService.GetCourses();
            if (Result == null)
            {
                return Ok(new List<Course>());
            }
            return Ok(Result);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(int CourseId)
        {
            Course Result = _courseService.GetCourse(CourseId);
            if (Result == null)
            {
                return NotFound(CourseId);
            }
            return Ok(Result);
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public ActionResult<Course> UpdateCourse(int CourseId, Course Course)
        {
            Course Result = _courseService.UpdateCourse(CourseId, Course);
            if (Result == null)
            {
                return NotFound(CourseId);
            }
            return Ok(Result);
        }

        // POST: api/Course
        [HttpPost]
        public ActionResult<Course> CreateCourse(Course Course)
        {
            Course Result = _courseService.CreateCourse(Course);
            if (Result == null)
            {
                return Conflict(Course.Name);
            }
            return Ok(Course);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteCourse(int CourseId)
        { 
            bool Result = _courseService.DeleteCourse(CourseId);
            if (Result)
            {
                return Ok();
            }
            return NotFound(CourseId);
        }
    }
}
