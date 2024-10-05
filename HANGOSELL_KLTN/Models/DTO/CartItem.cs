namespace HANGOSELL_KLTN.Models.DTO
{
    public class CartItem
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public Decimal productPrice { get; set; }
        public string anhsp { get; set; }
    }
}
