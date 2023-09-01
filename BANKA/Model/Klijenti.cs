using Microsoft.EntityFrameworkCore;

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BANKA.Model
{
    
    public class Klijenti
    {
      
        [Key]
        public int KlijentiId { get; set; } 
        [Required]
        public float OIB { get; set; }

        [Required]
        public string ime { get; set; }
        [Required]
        public string prezime { get; set; }
        [Required]
        public string adresa { get; set; }
      
        
        public string lozinka { get; set; }
        [Required]
      
        public string korisnickoIme { get; set; }
        
      
        public string brojRacuna { get; set; }
   

        public double stanjeRacuna { get; set; } = 0;
        [Required]

        public string emailKorisnik { get; set; }

        public string mobitel { get; set; } 





    }
}
