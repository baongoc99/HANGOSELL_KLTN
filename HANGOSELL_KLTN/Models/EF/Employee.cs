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
		public string CodeEmployee { get; set; }
		public string EmployeeName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string PhoneNumber { get; set; }
		public string? Address { get; set; }
		public DateTime JoinDate { get; set; }
		public bool Status { get; set; }
		// Thêm khóa ngoại RoleID $ể phân quyền
		public int RoleId { get; set; }
		public string? Avatar { get; set; }
		public string? Position { get; set; }
		// Thuộc tính $iều hướng $ến bảng Role
		[ForeignKey("RoleId")]
		public virtual Role Role { get; set; }
	}

}
