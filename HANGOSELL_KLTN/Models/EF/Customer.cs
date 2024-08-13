using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Customer")]
    public class Customer : CommonAbtract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên công ty không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên công ty không được vượt quá 100 ký tự.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Tên liên hệ không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên liên hệ không được vượt quá 100 ký tự.")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [StringLength(100, ErrorMessage = "Mật khẩu không được vượt quá 100 ký tự.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 ký tự.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        [StringLength(250, ErrorMessage = "Địa chỉ không được vượt quá 250 ký tự.")]
        public string Address { get; set; }
    }
}
