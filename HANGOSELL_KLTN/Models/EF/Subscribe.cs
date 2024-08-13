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

        [Required(ErrorMessage = "Email không được để trống.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ngày tạo không được để trống.")]
        public DateTime CreateDate { get; set; }
    }
}
