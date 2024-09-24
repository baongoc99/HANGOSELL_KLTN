using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

public class StoreService
{
    private readonly ApplicationDbContext _context;

    public StoreService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Store> GetStoreAsync()
    {
        return await _context.Stores.FirstOrDefaultAsync();
    }
    public Store CreateStore(Store store)
    {
        _context.Stores.Add(store);
        _context.SaveChangesAsync();
        return store;
    }
    public Store UpdateStore(Store store)
    {
        _context.Stores.Update(store);
        _context.SaveChangesAsync();
        return store;
    }
    public Store GetStoreById(int id)
    {
        return _context.Stores.Find(id);
    }


    public async Task<QRCodeRequest> GetQRCodeRequestAsync()
    {
        return await _context.QRCodeRequests.FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateStoreAsync(Store model, IFormFile logo)
    {
        var store = await _context.Stores.FirstOrDefaultAsync();

        if (store == null)
        {
            return false;
        }

        store.StoreName = model.StoreName;
        store.Address = model.Address;
        store.PhoneNumber = model.PhoneNumber;
        store.Email = model.Email;

        if (logo != null && logo.Length > 0)
        {
            // Xử lý lưu ảnh logo
            var filePath = Path.Combine("wwwroot/images", Path.GetFileName(logo.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await logo.CopyToAsync(stream);
            }
            store.Logo = $"/images/{Path.GetFileName(logo.FileName)}";
        }

        _context.Update(store);
        await _context.SaveChangesAsync();

        return true;
    }
}
