using System.ComponentModel.DataAnnotations;

namespace HANGOSELL_KLTN.Models
{
    public class CommonAbtract
    {
        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string? CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string? ModifiedBy { get; set; }
    }
}
