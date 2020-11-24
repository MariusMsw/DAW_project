using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProiectDAW.Entities;

namespace ProiectDAW.Data
{
    public class Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<EmployeeCourse> EmployeeCourses { get; set; }

        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Department 1 : M Employee
            builder.Entity<Department>()
                .HasMany(x => x.Employees)
                .WithOne(y => y.Department);

            //Employee 1 : 1 Laptop

            builder.Entity<Laptop>()
                .HasOne(x => x.Employee)
                .WithOne(y => y.Laptop)
                .HasForeignKey<Employee>(z => z.LaptopId);

            // Employee M : M Course

            builder.Entity<EmployeeCourse>()
                .HasOne<Employee>(x => x.Employee)
                .WithMany(y => y.EmployeeCourses)
                .HasForeignKey(z => z.EmployeeId);

            builder.Entity<EmployeeCourse>()
                .HasOne<Course>(x => x.Course)
                .WithMany(y => y.EmployeeCourses)
                .HasForeignKey(z => z.CourseId);

            builder.Entity<User>()
                .HasAlternateKey(x => x.Mail);

            builder.Entity<Employee>()
                .Property(f => f.EmployeeId)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
        }
    }
}
