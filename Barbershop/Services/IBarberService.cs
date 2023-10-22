using barbershopApi.Models;

namespace barbershopApi.Services
{
    public interface IBarberService
    {
        Task<IEnumerable<Barber>> GetBarbersAsync(); // Get a list of all barbers
        Task<Barber> GetBarberByIdAsync(string barberId); // Get a specific barber by ID
        Task<Barber> CreateBarberAsync(Barber barber); // Create a new barber
        Task<Barber> UpdateBarberAsync(string barberId, Barber barber); // Update an existing barber
        Task<Barber> DeleteBarberAsync(string barberId); // Delete a specific barber by ID
    }
}
