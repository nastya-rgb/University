using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base (options)
        { 
           
        }
        public DbSet<Student> Students{get;set;}
        public DbSet<Discipline> Disciplines{get;set;}
        public DbSet<Teacher> Teachers{get;set;}
         
    }
}