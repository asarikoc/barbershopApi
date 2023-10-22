using System.ComponentModel.DataAnnotations;

namespace barbershopApi.Models
{
    public class Barber
    {
        [Key]
        public string BarberID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Navigation Properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
