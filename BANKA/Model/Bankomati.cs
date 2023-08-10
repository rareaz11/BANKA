using System;
using System.ComponentModel.DataAnnotations;

namespace BANKA.Model
{
    public class Bankomati
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string adresa { get; set; }
        [Required]

        public string grad { get; set; }


        public decimal novacUBankomatu { get; set; } = 100000;
        
        
        
    }
}
