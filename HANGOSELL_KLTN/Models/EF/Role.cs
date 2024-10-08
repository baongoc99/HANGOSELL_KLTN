using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
	[Table("tb_Role")]
	public class Role
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string RoleName { get; set; }
		// Điều hướng đến Employee
		public virtual ICollection<Employee> Employees { get; set; }
		// Điều hướng đến Customer
	}

}
