using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANKA.Model
{
    public class OsobniPodatci
    {  
      
      [Key]
      public int OsobniId { get; set; }
        [ForeignKey("Zaposlenici")]

        public int ZaposleniciId { get; set; }
        

        [Required]
        public float OIB { get; set; }
        [Required]
        public bool IsDirektor { get; set; }    
        [Required]
        public bool IsBankar { get; set; }
      [Required]
        public string Adresa { get; set; }

        [Required]

        public string Email { get; set; }
        public string Mobitel { get; set; }
        [Required]
        public DateTime DatumRodeanja { get; set; } 
        [Required]
        public string Nacionalonst { get; set; }    
        
        [Required]
        public int dob { get; set; }

      
        [Required]
        public DateTime datumZaposljenja { get; set; }









    }
}
