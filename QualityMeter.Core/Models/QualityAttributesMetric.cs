using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMeter.Core.Models
{
    [Table("tb_QualityAttributesMetrics")]
    public class QualityAttributesMetric : CommonBaseBusinessEntity
    {
        [Required]
        [StringLength(500, MinimumLength = 2)]
        [Index(IsUnique = true)]

        public string Name { get; set; }

        public string Description { get; set; }

        [Index]
        [Required]
        public Guid CriteriaId { get; set; }


        [ForeignKey(nameof(CriteriaId))]
        public virtual Criteria Criteria { get; set; }

        [Required]
        public TypeOfMetric TypeOfMetric { get; set; }

        [Required]
        [StringLength(1)]
        public string Quantification { get; set; }

        [Required]
        public float StandardValue { get; set; }

        [Required]
        public float EvaluationValue { get; set; }

        [StringLength(30)]
        public string RuteBased { get; set; }

        [Index]
        public Guid? RelatedToId { get; set; }


        [ForeignKey(nameof(RelatedToId))]
        public virtual QualityAttributesMetric RelatedTo { get; set; }

        [Index]
        public Guid? AganistId { get; set; }


        [ForeignKey(nameof(AganistId))]
        public virtual QualityAttributesMetric Aganist { get; set; }
    }

}
