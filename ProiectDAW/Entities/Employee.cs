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

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int LaptopId { get; set; }

        public Laptop Laptop { get; set; }

        public ICollection<EmployeeCourse> EmployeeCourses { get; set; }

    }
}
