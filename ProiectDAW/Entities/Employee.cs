using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Mail { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public int DepartmentId { get; set; } = 0;

        public Department Department { get; set; } = null;

        public int LaptopId { get; set; } = 0;

        public Laptop Laptop { get; set; } = null;

        public ICollection<EmployeeCourse> EmployeeCourses { get; set; } = null;

    }
}
