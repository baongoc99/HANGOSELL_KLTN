namespace HANGOSELL_KLTN.Models.EF
{
    public class ModelDataset
    {
        public List<Role> roles { get; set; }
        public Role role { get; set; }
        public List<ProductCategory> categories { get; set; }
        public List<Product> products { get; set; }
        public Employee employee { get; set; }
        public ProductCategory category { get; set; }
        public Product product { get; set; }
        public Order order { get; set; }
        public Customer customer { get; set; }
        public List<OrderDetailCustomer> orderDetailCustomers { get; set; }
        public List<OrderDetail> orderDetail { get; set; }
        public OrderDetail orderDetal { get; set; }

        public List<InvoiceViewModel> invoices { get; set; }
        public InvoiceViewModel invoiceViewModel { get; set; }
        public Store store { get; set; }
        public QRCodeRequest qRCodeRequest { get; set; }
        public List<QRCodeRequest> qRCodeRequests { get; set; }

    }
}
