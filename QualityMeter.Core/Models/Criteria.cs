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
        [Index("IX_Name_FactorId", IsUnique = true, Order = 1)]

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Index("IX_Name_FactorId", IsUnique = true, Order = 2)]
        public Guid FactorId { get; set; }


        [ForeignKey(nameof(FactorId))]
        public virtual Factor Factor { get; set; }

    }
}
