﻿using ProiectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
       public Course GetCourseByName(string name);

        public Course GetCourseAllDetails(int CourseId);

        public List<Course> GetCoursesAllDetails();
    }
}
