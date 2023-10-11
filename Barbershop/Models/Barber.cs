using System.ComponentModel.DataAnnotations;

namespace barbershopApi.Models
{
    public class Barber
    {
        [Key]
        public int BarberID { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }
        public string ImageURL { get; set; }

        // Navigation Properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
