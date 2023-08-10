using Microsoft.EntityFrameworkCore;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANKA.Model
{
    public class Zaposlenici
    
    {
        public Zaposlenici() 
        {
            Osobni = new HashSet<OsobniPodatci>();
        }
        [Key]
        public int ZaposleniciId { get; set; } 
        [Required] 
        public float OIB { get; set; }
       
       
        [Required]
        
        public string Ime { get; set; }
        [Required]
      
        public string Prezime { get; set; }
        [Required]
       
        public string KorisnickoIme { get; set; }

      
        public string lozinka { get; set; }
        [Required]
       
       
        public string email { get; set; }

       public virtual ICollection<OsobniPodatci> Osobni { get; set; }


    }
}
