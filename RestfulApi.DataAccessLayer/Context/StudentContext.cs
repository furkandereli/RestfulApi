using Microsoft.EntityFrameworkCore;
using RestfulApi.EntityLayer.Entities;

namespace RestfulApi.DataAccessLayer.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
