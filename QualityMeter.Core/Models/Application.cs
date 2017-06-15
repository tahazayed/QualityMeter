using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMeter.Core.Models
{
    [Table("tb_Application")]
    public class Application : CommonBaseBusinessEntity
    {
        [Required]
        [StringLength(500, MinimumLength = 2)]

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]

        public string Customer { get; set; }


    }
}
