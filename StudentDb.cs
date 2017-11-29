using Microsoft.EntityFrameworkCore;
using System;

namespace StudentAPI
{
    public class StudentDb : DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            optionsBuilder.UseSqlite($"Filename=./Db/{environment}_Students.db");
        }
    }
}