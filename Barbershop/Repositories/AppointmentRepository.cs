using barbershopApi.Models;
using System.Text.Json;
using System.Text;

namespace barbershopApi.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HttpClient _httpClient;

        public AppointmentRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync(string barberId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/appointments?barberId={barberId}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var appointments = JsonSerializer.Deserialize<IEnumerable<Appointment>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Use this option if your JSON property names are in camelCase
                });
                return appointments;
            }
            catch (HttpRequestException)
            {
                // Handle exception
                return null;
            }
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/appointments/{appointmentId}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var appointment = JsonSerializer.Deserialize<Appointment>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Use this option if your JSON property names are in camelCase
                });
                return appointment;
            }
            catch (HttpRequestException)
            {
                // Handle exception
                return null;
            }
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            try
            {
                var jsonAppointment = JsonSerializer.Serialize(appointment);
                var content = new StringContent(jsonAppointment, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/appointments", content);
                response.EnsureSuccessStatusCode();
                var createdAppointment = JsonSerializer.Deserialize<Appointment>(
                    await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return createdAppointment;
            }
            catch (HttpRequestException)
            {
                // Handle exception
                return null;
            }
        }

        public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
        {
            try
            {
                var jsonAppointment = JsonSerializer.Serialize(appointment);
                var content = new StringContent(jsonAppointment, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"api/appointments/{appointment.AppointmentID}", content);
                response.EnsureSuccessStatusCode();
                var updatedAppointment = JsonSerializer.Deserialize<Appointment>(
                    await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return updatedAppointment;
            }
            catch (HttpRequestException)
            {
                // Handle exception
                return null;
            }
        }

        public async Task<Appointment> DeleteAppointmentAsync(int appointmentId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/appointments/{appointmentId}");
                response.EnsureSuccessStatusCode();
                var deletedAppointment = JsonSerializer.Deserialize<Appointment>(
                    await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return deletedAppointment;
            }
            catch (HttpRequestException)
            {
                // Handle exception
                return null;
            }
        }
    }
}