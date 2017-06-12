using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMeter.Core.Models
{

    [Table("tb_Factors")]
    public class Factor : CommonBaseBusinessEntity
    {
        [Required]
        [StringLength(500, MinimumLength = 2)]
        [Index(IsUnique = true)]

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid SubjectId { get; set; }


        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; }
    }
}
