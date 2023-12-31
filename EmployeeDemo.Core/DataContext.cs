﻿using EmployeeDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDemo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeDemo.Models.Employee> Employees { get; set; } = default!;

        public DbSet<EmployeeDemo.Models.Department> Departments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Marketing" },
                new Department { DepartmentId = 4, DepartmentName = "Sales" }
            );
            modelBuilder.Entity<Employee>()
                .Property(b => b.CreateDate)
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Employee>()
                .Property(b => b.CreatedBy)
                .HasDefaultValue(1);
            modelBuilder.Entity<Employee>()
                .Property(b => b.UpdatedBy)
                .HasDefaultValue(null);
            modelBuilder.Entity<Employee>()
             .Property(b => b.UpdatedDate)
             .HasDefaultValue(null);
        }
    }
}
