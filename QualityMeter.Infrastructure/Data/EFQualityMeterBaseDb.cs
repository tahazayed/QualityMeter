using QualityMeter.Core.Models;
using System.Data.Entity;

namespace QualityMeter.Infrastructure.Data
{
    public class EfQualityMeterBaseDb : DbContext
    {
        public EfQualityMeterBaseDb()
            : base("QualityMeterDB")
        {


        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<QualityAttributesMetric> QualityAttributesMetrics { get; set; }

        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationEvaluation> ApplicationEvaluations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QualityAttributesMetric>().
                HasOptional(e => e.RelatedTo).
                WithMany().
                HasForeignKey(m => m.RelatedToId);

            modelBuilder.Entity<QualityAttributesMetric>().
                HasOptional(e => e.Against).
                WithMany().
                HasForeignKey(m => m.AgainstId);

            modelBuilder.Entity<Factor>().HasRequired(i => i.Subject).WithMany().WillCascadeOnDelete(false);


            modelBuilder.Entity<QualityAttributesMetric>().HasRequired(i => i.Criteria).WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
