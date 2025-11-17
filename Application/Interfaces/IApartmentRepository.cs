using Domain.Entities;

namespace Application.Interfaces;

public interface IApartmentRepository
{
    Task<Apartment?> GetByIdAsync(int id);
    Task<List<Apartment>> GetAllAsync();
    Task<int> AddAsync(Apartment apt);
    Task UpdateAsync(Apartment apt);
    Task DeleteAsync(int id);
}
