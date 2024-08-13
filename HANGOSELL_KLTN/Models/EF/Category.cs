using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HANGOSELL_KLTN.Models.EF
{
    [Table("tb_Category")]
    public class Category : CommonAbtract
    {
        public Category()
        {
            this.News = new HashSet<News>();
            this.Posts = new HashSet<Posts>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống.")]
        [StringLength(100, ErrorMessage = "Tiêu đề không được vượt quá 100 ký tự.")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Vị trí không được để trống.")]
        public int Position { get; set; }

        [StringLength(150, ErrorMessage = "Tiêu đề SEO không được vượt quá 150 ký tự.")]
        public string? SeoTitle { get; set; }

        [StringLength(150, ErrorMessage = "Từ khóa SEO không được vượt quá 150 ký tự.")]
        public string? SeoKeyword { get; set; }

        [StringLength(250, ErrorMessage = "Mô tả SEO không được vượt quá 250 ký tự.")]
        public string? SeoDescription { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}
