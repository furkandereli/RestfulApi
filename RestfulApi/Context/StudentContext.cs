using Microsoft.EntityFrameworkCore;
using RestfulApi.Entities;

namespace RestfulApi.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) 
        { 
        }

        public DbSet<Student> Students { get; set; }
    }
}
