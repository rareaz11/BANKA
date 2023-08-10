using System.ComponentModel.DataAnnotations;

namespace BANKA.Model
{
    public class Poslovnice
    {
        [Key]
        public int PoslovnicaId { get; set; }
       
        public int ZaposlenikID { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string mjesto { get; set; }
        [Required]
        public string kontakt { get; set; }    
    }
}
