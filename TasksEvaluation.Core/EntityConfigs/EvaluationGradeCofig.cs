using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasksEvaluation.Core.Entities.Business;

namespace TasksEvaluation.Core.EntityConfigs
{
    public class EvaluationGradeCofig : IEntityTypeConfiguration<EvaluationGrade>
    {
        public void Configure(EntityTypeBuilder<EvaluationGrade> builder)
        {
            builder.HasMany(e => e.Solution)
                    .WithOne(e => e.Grade);

        }
    }
}
