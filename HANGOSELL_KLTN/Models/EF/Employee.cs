using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Employee")]
    public class Employee : CommonAbtract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã nhân viên không được để trống.")]
        [StringLength(20, ErrorMessage = "Mã nhân viên không được vượt quá 20 ký tự.")]
        public string CodeEmployee { get; set; }

        [Required(ErrorMessage = "Tên nhân viên không được để trống.")]
        [StringLength(100, ErrorMessage = "Tên nhân viên không được vượt quá 100 ký tự.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [StringLength(100, ErrorMessage = "Mật khẩu không được vượt quá 100 ký tự.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được để trống.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [StringLength(15, ErrorMessage = "Số điện thoại không được vượt quá 15 ký tự.")]
        public string PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Ngày gia nhập không được để trống.")]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống.")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "ID vai trò không được để trống.")]
        public int RoleID { get; set; }

        [StringLength(250, ErrorMessage = "Đường dẫn avatar không được vượt quá 250 ký tự.")]
        public string? Avatar { get; set; }

        [StringLength(100, ErrorMessage = "Chức vụ không được vượt quá 100 ký tự.")]
        public string? Position { get; set; }

        // Thuộc tính điều hướng đến bảng Role nếu cần
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
    }
}
