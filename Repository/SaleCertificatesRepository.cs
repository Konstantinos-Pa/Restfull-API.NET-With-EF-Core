
using Assignment.Models;
using Assignment.Service;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repository
{
    public class SaleCertificatesRepository : ISaleCertificatesRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleCertificatesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaleCertificate>> GetSaleCertificatesAsync()
        {
            return await _context.SaleCertificates.ToListAsync();
        }

        public async Task<SaleCertificate> GetSaleCertificateByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id) + " must be greater than zero. (Thrown from GetSaleCertificateByIdAsync)");
            }

            SaleCertificate? SaleCertificate = await _context.SaleCertificates
                .FirstOrDefaultAsync(c => c.Id == id);

            if (SaleCertificate == null)
            {
                throw new Exception("SaleCertificate not found (Thrown from GetSaleCertificateByIdAsync)");
            }

            return SaleCertificate;
        }

        public async Task<int> AddSaleCertificateAsync(SaleCertificate SaleCertificate)
        {
            if (SaleCertificate == null)
            {
                throw new ArgumentNullException(nameof(SaleCertificate) + " is null (Thrown from AddSaleCertificateAsync)");
            }

            await _context.SaleCertificates.AddAsync(SaleCertificate);
            await _context.SaveChangesAsync();
            return SaleCertificate.Id;
        }

        public async Task UpdateSaleCertificateAsync(int id, SaleCertificate SaleCertificate)
        {
            if (SaleCertificate == null)
            {
                throw new ArgumentNullException(nameof(SaleCertificate) + " is null (Thrown from UpdateSaleCertificateAsync)");
            }

            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id) + " must be greater than zero. (Thrown from UpdateSaleCertificateAsync)");
            }

            SaleCertificate existingSaleCertificate = await GetSaleCertificateByIdAsync(id);

            // Update fields
            existingSaleCertificate.Title = SaleCertificate.Title;
            existingSaleCertificate.AssessmentTestCode = SaleCertificate.AssessmentTestCode;
            existingSaleCertificate.Description = SaleCertificate.Description;
            existingSaleCertificate.Price = SaleCertificate.Price;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSaleCertificateAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id) + " must be greater than zero. (Thrown from DeleteSaleCertificateAsync)");
            }

            SaleCertificate existingSaleCertificate = await GetSaleCertificateByIdAsync(id);

            _context.SaleCertificates.Remove(existingSaleCertificate);
            await _context.SaveChangesAsync();
        }




    }





}
