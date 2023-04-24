using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileRecharge.Models
{
    public class RechargePlans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Nullable<int> Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Validity { get; set; }

    }
}
