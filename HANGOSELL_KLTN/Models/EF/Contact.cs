using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Contact")]
    public class Contact : CommonAbtract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Website không được vượt quá 250 ký tự.")]
        public string? Website { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        [StringLength(1000, ErrorMessage = "Tin nhắn không được vượt quá 1000 ký tự.")]
        public string? Message { get; set; }

        [Required(ErrorMessage = "Trạng thái đọc không được để trống.")]
        public bool IsRead { get; set; }
    }
}
