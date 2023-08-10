using Microsoft.EntityFrameworkCore;

namespace BANKA.Model
{
    public class APIDbContext: DbContext
    {
        public DbSet<Poslovnice> Poslovnice { get; set; }   
        public DbSet<Bankomati>Bankomatis { get; set; } 
        public DbSet<OsobniPodatci> OsobniPodatci { get; set; }
        public DbSet<Zaposlenici> Zaposlenici { get; set; }

        public DbSet<Transakcije> Transakcije { get; set; }
        

        public DbSet<Klijenti> Klijenti { get; set; }  
          

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=ANTONIO\AZELIC;Initial Catalog=MOJPOKUSAJ;Integrated Security=True");
        }
    }
}
