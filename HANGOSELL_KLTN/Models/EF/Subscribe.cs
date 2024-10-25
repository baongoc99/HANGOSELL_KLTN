using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Subscribe")]
    public class Subscribe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email không $ược $ể trống.")]
        [StringLength(100, ErrorMessage = "Email không $ược vượt quá 100 ký tự.")]
        [EmailAddress(ErrorMessage = "$ịa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ngày tạo không $ược $ể trống.")]
        public DateTime CreateDate { get; set; }
    }
}
