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
    public string? CompanyName { get; set; }
    public string ContactPerson { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    // Thêm khóa ngoại RoleId để phân quyền
 
}

}
