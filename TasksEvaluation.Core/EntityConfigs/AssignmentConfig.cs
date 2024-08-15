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
   //
    public class AssignmentConfig : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.Property(t => t.Title).IsRequired().HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(100);
            builder.HasOne(t => t.Group)
                   .WithMany(t => t.Assignments);
            builder.HasMany(t => t.Solutions)
                   .WithOne(t => t.Assignment);
                  
            
        }
    }
}
