namespace HANGOSELL_KLTN.Models.EF
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } // Thêm email nếu cần
        public DateTime CreatedDate { get; set; }
        public string? Logo { get; set; } // $ường dẫn logo của cửa hàng
    }
}
