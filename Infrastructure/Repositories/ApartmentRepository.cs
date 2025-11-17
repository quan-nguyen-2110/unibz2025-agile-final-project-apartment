using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ApartmentRepository : IApartmentRepository
{
    private readonly AppDbContext _db;

    public ApartmentRepository(AppDbContext db)
        => _db = db;

    public async Task<int> AddAsync(Apartment apt)
    {
        _db.Apartments.Add(apt);
        await _db.SaveChangesAsync();
        return apt.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var apt = await _db.Apartments.FindAsync(id);
        if (apt != null)
        {
            _db.Apartments.Remove(apt);
            await _db.SaveChangesAsync();
        }
    }

    public Task<List<Apartment>> GetAllAsync()
        => _db.Apartments.ToListAsync();

    public Task<Apartment?> GetByIdAsync(int id)
        => _db.Apartments.FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(Apartment apt)
    {
        _db.Apartments.Update(apt);
        await _db.SaveChangesAsync();
    }
}
