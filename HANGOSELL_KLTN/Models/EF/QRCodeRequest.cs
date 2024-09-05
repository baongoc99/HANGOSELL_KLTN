namespace HANGOSELL_KLTN.Models.EF
{
    public class QRCodeRequest
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string AcqId { get; set; }
        public string AddInfo { get; set; }
        public string Template { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
