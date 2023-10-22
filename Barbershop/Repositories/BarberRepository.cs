using barbershopApi.Models;
using System.Text.Json;
using System.Text;

namespace barbershopApi.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        private readonly HttpClient _httpClient;

        public BarberRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Barber>> GetBarbersAsync()
        {
            var response = await _httpClient.GetAsync("api/barbers"); // Adjust the API endpoint as needed
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Barber>>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Barber> GetBarberByIdAsync(string barberId)
        {
            var response = await _httpClient.GetAsync($"api/barbers/{barberId}"); // Adjust the API endpoint as needed
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Barber>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Barber> CreateBarberAsync(Barber barber)
        {
            var barberJson = JsonSerializer.Serialize(barber);
            var content = new StringContent(barberJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/barbers", content); // Adjust the API endpoint as needed
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Barber>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Barber> UpdateBarberAsync(string barberId, Barber barber)
        {
            var barberJson = JsonSerializer.Serialize(barber);
            var content = new StringContent(barberJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/barbers/{barberId}", content); // Adjust the API endpoint as needed
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Barber>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Barber> DeleteBarberAsync(string barberId)
        {
            var response = await _httpClient.DeleteAsync($"api/barbers/{barberId}"); // Adjust the API endpoint as needed
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Barber>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
