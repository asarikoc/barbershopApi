﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace barbershopApi.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [ForeignKey("Barber")]
        public int BarberID { get; set; }

        public string CustomerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        // Navigation Property
        public Barber Barber { get; set; }
    }
}
