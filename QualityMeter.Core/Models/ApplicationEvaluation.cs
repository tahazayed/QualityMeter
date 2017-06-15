using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMeter.Core.Models
{
    [Table("tb_ApplicationEvaluations")]
    public class ApplicationEvaluation : CommonBaseBusinessEntity
    {

        [Required]
        public Guid QualityAttributesMetricId { get; set; }


        [ForeignKey(nameof(QualityAttributesMetricId))]
        public virtual QualityAttributesMetric QualityAttributesMetric { get; set; }

        [Required]
        public Guid ApplicationId { get; set; }


        [ForeignKey(nameof(ApplicationId))]
        public virtual Application Application { get; set; }

        [Required]
        public float QualityValue { get; set; }

        [Required]
        public float UserValue { get; set; }

    }
}
