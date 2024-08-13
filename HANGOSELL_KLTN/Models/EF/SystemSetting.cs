using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_SystemSetting")]
    public class SystemSetting
    {
        [Key]
        [Required(ErrorMessage = "Khóa thiết lập không được để trống.")]
        [StringLength(100, ErrorMessage = "Khóa thiết lập không được vượt quá 100 ký tự.")]
        public string SettingKey { get; set; }

        [Required(ErrorMessage = "Giá trị thiết lập không được để trống.")]
        [StringLength(500, ErrorMessage = "Giá trị thiết lập không được vượt quá 500 ký tự.")]
        public string SettingValue { get; set; }

        [StringLength(1000, ErrorMessage = "Mô tả thiết lập không được vượt quá 1000 ký tự.")]
        public string? SettingDescription { get; set; }
    }
}
