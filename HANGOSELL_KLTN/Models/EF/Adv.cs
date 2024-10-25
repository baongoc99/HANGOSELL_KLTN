using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Adv")]
    public class Adv : CommonAbtract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống.")]
        [StringLength(100, ErrorMessage = "Tiêu đề không được vượt quá 100 ký tự.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống.")]
        [StringLength(250, ErrorMessage = "đường dẫn hình ảnh không được vượt quá 250 ký tự.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Loại không được để trống.")]
        public int Type { get; set; }

        [StringLength(500, ErrorMessage = "Liên kết không được vượt quá 500 ký tự.")]
        public string? Link { get; set; }

    }
}
