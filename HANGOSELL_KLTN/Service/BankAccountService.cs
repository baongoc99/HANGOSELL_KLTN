using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;

namespace HANGOSELL_KLTN.Service
{
    public class BankAccountService
    {
        private readonly ApplicationDbContext _context;

        public BankAccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<QRCodeRequest> GetAllBankAccounts()
        {
            return _context.QRCodeRequests.ToList(); // Lấy danh sách tài khoản ngân hàng
        }

        public QRCodeRequest GetBankAccountById(int id)
        {
            return _context.QRCodeRequests.Find(id); // Lấy tài khoản ngân hàng theo id
        }

        public void AddBankAccount(QRCodeRequest bankAccount)
        {
            _context.QRCodeRequests.Add(bankAccount); // Thêm tài khoản ngân hàng
            _context.SaveChanges();
        }

        public void UpdateBankAccount(QRCodeRequest bankAccount)
        {
            _context.QRCodeRequests.Update(bankAccount); // Cập nhật tài khoản ngân hàng
            _context.SaveChanges();
        }

        public void DeleteBankAccount(int id)
        {
            var bankAccount = _context.QRCodeRequests.Find(id);
            if (bankAccount != null)
            {
                _context.QRCodeRequests.Remove(bankAccount); // Xóa tài khoản ngân hàng
                _context.SaveChanges();
            }
        }
    }
}
