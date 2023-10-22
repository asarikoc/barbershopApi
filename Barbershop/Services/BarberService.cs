using barbershopApi.Models;
using barbershopApi.Repositories;

namespace barbershopApi.Services
{
    public class BarberService : IBarberService
    {
        private readonly IBarberRepository _barberRepository;

        public BarberService(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        public async Task<IEnumerable<Barber>> GetBarbersAsync()
        {
            return await _barberRepository.GetBarbersAsync();
        }

        public async Task<Barber> GetBarberByIdAsync(string barberId)
        {
            return await _barberRepository.GetBarberByIdAsync(barberId);
        }

        public async Task<Barber> CreateBarberAsync(Barber barber)
        {
            return await _barberRepository.CreateBarberAsync(barber);
        }

        public async Task<Barber> UpdateBarberAsync(string barberId, Barber barber)
        {
            return await _barberRepository.UpdateBarberAsync(barberId, barber);
        }

        public async Task<Barber> DeleteBarberAsync(string barberId)
        {
            return await _barberRepository.DeleteBarberAsync(barberId);
        }
    }
}
