namespace HANGOSELL_KLTN.Models.EF
{
    public class ModelDataset
    {
        public List<Role> roles { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
        public Employee employee { get; set; }
        public Category category { get; set; }
        public Product product { get; set; }
    }
}
