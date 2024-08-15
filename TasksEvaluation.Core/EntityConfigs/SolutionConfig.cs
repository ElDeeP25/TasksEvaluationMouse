
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.EntityConfigs
{
    public class SolutionConfig : IEntityTypeConfiguration<Solution>
    {
        public void Configure(EntityTypeBuilder<Solution> builder)
        {
            builder.Property(s=>s.Notes).IsRequired().HasMaxLength(1000);
            builder.HasOne(s => s.Student)
                   .WithMany(s => s.Solutions);
                  
        }
    }
}
