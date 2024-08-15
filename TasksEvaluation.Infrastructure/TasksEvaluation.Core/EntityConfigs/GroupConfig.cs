using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.EntityConfigs
{
    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(t => t.Title).IsRequired().HasMaxLength(50);
            builder.HasMany(g => g.Students)
                   .WithOne(g => g.Group);
                   
            builder.HasMany(g => g.Assignments)
                   .WithOne(g => g.Group);
                   
        }
    }
}
