
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.Entities.Business;
namespace TasksEvaluation.Core.EntityConfigs
{
    public class CourseConfig:IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder) {
            builder.Property(c=>c.Title).IsRequired().HasMaxLength(50);
            builder.Property(c=>c.IsCompleted).HasDefaultValue(false);
            builder.HasMany(x => x.Groups)
                   .WithOne(c => c.Course);
                  
        }
    }
}
