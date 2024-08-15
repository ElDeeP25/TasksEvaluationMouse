using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EvaluationGrade> EvaluationGrades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        /*public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }*/
        //rotected override void OnConfiguring(DbContextOptionsBuilder
        //   optionsBuilder)
        //
        //   optionsBuilder.UseSqlServer("Server=EMAN\\SQLEXPRESS;Database=TasksEvaluationX;TrustServerCertificate=True;Trusted_Connection=True; ");
        //

    }
}
