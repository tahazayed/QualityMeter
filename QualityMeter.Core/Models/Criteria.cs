using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMeter.Core.Models
{
    [Table("tb_Criterias")]
    public class Criteria : CommonBaseBusinessEntity
    {
        [Required]
        [StringLength(500, MinimumLength = 2)]
        [Index(IsUnique = true)]

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid FactorId { get; set; }


        [ForeignKey(nameof(FactorId))]
        public virtual Factor Factor { get; set; }

    }
}
