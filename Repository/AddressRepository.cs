using Assignment.Models;
using Assignment.Service;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repository
{
    public class AddressRepository
    {
        private readonly PostgresDbContext _context;
        public AddressRepository(PostgresDbContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address?> GetAddressByIdAsync(int id)
        {
            if (id == null || id == 0)
            {
                throw new ArgumentNullException(nameof(id) + "Is Null (Thrown from GetAddressByIdAsync)");
            }
            Address? address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if (address == null)
            {
                throw new Exception("Address not found (Thrown from GetAddressByIdAsync)");
            }
            return address;
        }

        public async Task<Address> AddAddressAsync(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address) + "Is Null (Thrown from AddAddressAsync)");
            }
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAddressAsync(int id,Address address)
        {
            if (id == null || id == 0)
            {
                throw new ArgumentNullException(nameof(id) + "Is Null (Thrown from UpdateAddressAsyncc)");
            } else if (address == null)
            {
                throw new ArgumentNullException(nameof(address) + "Is Null (Thrown from UpdateAddressAsync)");
            }
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task DeleteAddressAsync(int id)
        {
            if (id == null || id == 0)
            {
                throw new ArgumentNullException(nameof(id) + "Is Null (Thrown from DeleteAddressAsync)");
            }
            Address? address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if (address == null)
            {
                throw new Exception("Address not found (Thrown from DeleteAddressAsync)");
            }
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
