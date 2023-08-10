using BANKA.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BANKA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            using (APIDbContext db = new APIDbContext())
            
            {
                //var listaKorisnika =db.Klijenti.ToList();

                //Random rngOib = new Random();
                //Random rng2 = new Random();
                //Transakcije transakcije = new Transakcije();
                //Klijenti klijenti = new Klijenti();
                //klijenti.ime = "Ante";
                //klijenti.prezime = "Antic";
                //klijenti.korisnickoIme ="Antic123";

                //klijenti.lozinka = "1234";
                //klijenti.adresa="Zagreb 8";
                //klijenti.OIB = rngOib.Next(100000000,999999999);
                //klijenti.brojRacuna ="HR"+rng2.Next(10000000,99999999).ToString();
                //foreach (var item in listaKorisnika) 
                //{
                //    if (item.korisnickoIme == klijenti.korisnickoIme || item.OIB==klijenti.OIB ||item.brojRacuna==klijenti.brojRacuna) 
                //    {

                //    }
                //}
                //UPLATA PREKO UPDATE KLIJENTAA
                //transakcije.KlijentiId = 2;
                //Klijenti klijenti1 = db.Klijenti.Find(transakcije.KlijentiId);
                //transakcije.vrijemeUplate = DateTime.Now;
                //transakcije.imeUplatitelja = "Pero";
                //transakcije.imeBanke = "Zadarska Banka";
                //transakcije.OIB = 481536208;
                //transakcije.iznos = 5000.65;
                //klijenti1.stanjeRacuna += transakcije.iznos;
                //transakcije.opis = "dar";
                //transakcije.brZiroRacu = "HR24167061";
                //foreach (var item in listaKorisnika) 
                //{
                //    if (item.brojRacuna == transakcije.brZiroRacu)
                //    {
                //        if(item.OIB == transakcije.OIB) 
                //        {
                //            db.Add(transakcije);
                //            db.Update(klijenti1);
                //            db.SaveChanges();

                //        }
                //    }


                //}





                //db.Transakcije.Add(transakcije);

                ///////////////////////////////////////////////////
                ///

                //var list=db.Klijentis.ToList();
                //Random rng1 = new Random();

                //Klijenti klijenti = new Klijenti();
                //klijenti.ime = "Josipa";

                //klijenti.prezime = "Petrovic";
                //klijenti.adresa = "ul.HRV 12";
                //klijenti.korisnickoIme = "Marinela123";
                //foreach (var item in list)
                //{
                //    if (klijenti.korisnickoIme == item.korisnickoIme) 
                //    {

                //        BadRequest();
                //    }
                //}
                //var x = db.Klijentis.Select(x => x.korisnickoIme == klijenti.korisnickoIme);
                //klijenti.lozina = "1234";
                //klijenti.OIB = rng1.Next(10000000, 999999999);
                //klijenti.brojRacuna = "HR" + rng1.Next(10000000, 999999999).ToString();


                //db.Klijentis.Add(klijenti);
                //h:
                //db.SaveChanges();



                ////////////////////////////////////////////////////////////////////////
                //PROBLEM AKO JE INTEGER AKO SE NISTA NE UNESE ONDA JE PROBLEM TO STO SE UNESE NULA A NE JAVI GRSKKU DA NIJE UNESENO
                //Zaposlenici zaposlenici = new Zaposlenici();
                //zaposlenici.KorisnickoIme = "Toni123";
                //zaposlenici.lozinka = "4321";
                //zaposlenici.OIB = 0;
                //zaposlenici.email = "toni@mate.com";
                //zaposlenici.Ime = "Marko";
                //zaposlenici.Prezime = "Markovic";
                //db.Zaposlenici.Add(zaposlenici);
                //db.SaveChanges();

                //OsobniPodatci osobniPodatci = new OsobniPodatci();
                //osobniPodatci.ZaposleniciId = 3;
                //osobniPodatci.dob = 22;
                //osobniPodatci.OIB = 321231233;
                //osobniPodatci.Email = "Email@email";
                //osobniPodatci.IsBankar = true;
                //osobniPodatci.IsDirektor = false;
                //osobniPodatci.Adresa = "Split 2";
                //osobniPodatci.Nacionalonst = "Hrvat";
                //db.OsobniPodatci.Add(osobniPodatci);
                //db.SaveChanges();




            }
            var rng = new Random();
           return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
