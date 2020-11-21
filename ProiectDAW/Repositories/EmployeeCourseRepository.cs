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
    }
}
