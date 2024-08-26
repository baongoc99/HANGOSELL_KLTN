namespace HANGOSELL_KLTN.Models
{
    public class InvoiceViewModel
    {
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string QRCodeUrl { get; set; }
    }
}
