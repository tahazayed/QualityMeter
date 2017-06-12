using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMeter.Core.Models
{
    [Table("tb_Subjects")]
    public class Subject : CommonBaseBusinessEntity
    {
        [Required]
        [StringLength(500, MinimumLength = 2)]
        [Index(IsUnique = true)]

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
