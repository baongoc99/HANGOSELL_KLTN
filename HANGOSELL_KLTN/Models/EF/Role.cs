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

        [Required(ErrorMessage = "Tên vai trò không được để trống.")]
        [StringLength(50, ErrorMessage = "Tên vai trò không được vượt quá 50 ký tự.")]
        public string RoleName { get; set; }
    }
}
