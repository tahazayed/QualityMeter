using System.ComponentModel.DataAnnotations.Schema;

namespace QualityMeter.Core.Models
{
    [Table("tb_Roles")]
    public class Role
    {
        public long Id { get; set; }
        public string Roles { get; set; }

        public bool IsSystem { get; set; }

        public Role()
        {
            IsSystem = false;
        }
    }
}