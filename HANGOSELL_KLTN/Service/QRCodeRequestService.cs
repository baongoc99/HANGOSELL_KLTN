using HANGOSELL_KLTN.Data;
using HANGOSELL_KLTN.Models.EF;
using Microsoft.EntityFrameworkCore;
using System;

namespace HANGOSELL_KLTN.Service
{
    public class QRCodeRequestService
    {
        private readonly ApplicationDbContext _context;

        public QRCodeRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QRCodeRequest>> GetAllAsync()
        {
            return await _context.QRCodeRequests.ToListAsync();
        }

        public async Task<QRCodeRequest> GetByIdAsync(int id)
        {
            return await _context.QRCodeRequests.FindAsync(id);
        }

        public async Task AddAsync(QRCodeRequest qrCodeRequest)
        {
            await _context.QRCodeRequests.AddAsync(qrCodeRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(QRCodeRequest qrCodeRequest)
        {
            _context.QRCodeRequests.Update(qrCodeRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var qrCodeRequest = await _context.QRCodeRequests.FindAsync(id);
            if (qrCodeRequest != null)
            {
                _context.QRCodeRequests.Remove(qrCodeRequest);
                await _context.SaveChangesAsync();
            }
        }
    }
}

