using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.infrastructure.Seed
{
    public static class Seeder
    {
        
        public static void ConfigurationTables(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course()
                {
                    Id = 1,
                    Title = "Front End",
                    EntryDate = DateTime.Now,
                    IsDeleted = false,
                    UpdateDate = DateTime.Now,
                },
                new Course()
                {
                    Id = 2,
                    Title = "Back End",
                    EntryDate = DateTime.Now,
                    IsDeleted = false,
                    UpdateDate = DateTime.Now,
                },
                new Course()
                {
                    Id = 3,
                    Title = "Full Stack",
                    EntryDate = DateTime.Now,
                    IsDeleted = false,
                    UpdateDate = DateTime.Now,
                }
            );
            modelBuilder.Entity<Group>().HasData(
               new Group()
               {
                   Id = 1,
                   Title = "A"                   
               },
                new Group()
                {
                    Id = 2,
                    Title = "B"
                },
                new Group()
                {
                    Id = 3,
                    Title = "C"
                }
            );

            modelBuilder.Entity<EvaluationGrade>().HasData(
                new EvaluationGrade()
                {
                    Id = 1,
                    Grade = "Good"
                },
                new EvaluationGrade()
                {
                    Id = 2,
                    Grade = "Very Good"
                }, new EvaluationGrade()
                {
                    Id = 3,
                    Grade = "Excellent"
                }
            );
           
        }
    
    }
}
