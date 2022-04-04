using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Avancerad_.NET.Models
{
    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, FName = "Erik", LName = "Norell", Title = "Utvecklare" });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 2, FName = "Viktor", LName = "Gunnarsson", Title = "Utvecklare" });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 3, FName = "Lukas", LName = "Rose", Title = "Utvecklare" });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 4, FName = "Erik", LName = "Risholm", Title = "Utvecklare" });

            modelBuilder.Entity<Project>().HasData(new Project { Id = 1, ProjectName = "Lion Bank"});
            modelBuilder.Entity<Project>().HasData(new Project { Id = 2, ProjectName = "Numbers Game"});
            modelBuilder.Entity<Project>().HasData(new Project { Id = 3, ProjectName = "Car Race application"});

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 1, HoursWorked = 5, WeekNumber = 12, EmployeeId = 1, ProjetId = 1});
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 2, HoursWorked = 10, WeekNumber = 12, EmployeeId = 1, ProjetId = 2});
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 3, HoursWorked = 2, WeekNumber = 12, EmployeeId = 2, ProjetId = 1});
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 4, HoursWorked = 15, WeekNumber = 12, EmployeeId = 2, ProjetId = 3});
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 5, HoursWorked = 7, WeekNumber = 12, EmployeeId = 3, ProjetId = 2});
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 6, HoursWorked = 7, WeekNumber = 12, EmployeeId = 3, ProjetId = 3});
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 7, HoursWorked = 1, WeekNumber = 12, EmployeeId = 4, ProjetId = 1});
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { Id = 8, HoursWorked = 20, WeekNumber = 12, EmployeeId = 4, ProjetId = 3});
        }
    }
}
