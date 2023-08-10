
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANKA.Model
{
    public class Transakcije
    {
       
        [Key]
        public int TransId { get; set; }

     

        [Required]
        public float OIB { get; set; }
      
        [Required]
        public string opis { get; set; }
        [Required]
        public string imeUplatitelja { get; set; }
        [Required]
        public DateTime vrijemeUplate { get; set; }=DateTime.Now;   
        [Required]
        public string imeBanke { get; set; }   
        [Required]
        public double iznos { get; set; }
        [Required]
       
        public string brZiroRacu { get; set; }

        

       

       





    }
}
