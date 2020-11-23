using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Entities
{
    public class EmployeeCourse
    {
        [Key]
        public int EmployeeCourseId { get; set; }

        public int EmployeeId { get; set; } = 0;

        public int CourseId { get; set; } = 0;

        public Employee Employee { get; set; } = null;

        public Course Course { get; set; } = null;
    }
}
