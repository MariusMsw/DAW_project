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

        public int EmployeeId { get; set; }

        public int CourseId { get; set; }

        public Employee Employee { get; set; }

        public Course Course { get; set; }
    }
}
