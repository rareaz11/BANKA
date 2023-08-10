using BANKA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BANKA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlijentiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var db = new APIDbContext();
            
            var list = db.Klijenti.ToList();
            foreach (var item in list) 
            {
                //if(item.emailKorisnik=="")
                //{

                //   return BadRequest(item.ime +" email ne smije biti prazno ");
                //}
            }

            if(list!=null)
                return Ok(list);  

            else
                return BadRequest("lista je prazna");

        }

        [HttpPost]
        public IActionResult DodajNovogKlijenta(Klijenti klijenti) 
        {
           var db=new APIDbContext();
            var popis = db.Klijenti.ToList();

            string sifra = "";
            Random random = new Random();

            string a = "abcdefghijklmnoprstxyzABCDEFGHIJKLMNOPRSTYXZWQ0123456789/*#$%";
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(0, 61);
                sifra += a[x];

            }
            klijenti.lozinka = sifra;

            Random random2 = new Random();  
            Random random3 = new Random();
            klijenti.brojRacuna="HR"+random2.Next(100000,9999999).ToString()+random3.Next(10000000, 99999999).ToString();

            foreach (var item in popis) 
            {
                if (klijenti.korisnickoIme == item.korisnickoIme) 
                {
                   return Conflict("KORISNICKO IME VEC POSTOJI");
                }
                else if (klijenti.OIB == item.OIB)
                {
                    return BadRequest("UNESENI OIB VEC POSTOJI");
                }

                else if (klijenti.brojRacuna == item.brojRacuna) 
                {
                    return BadRequest("NE SMIJU BITI 2 ISTA RACUNA:" +klijenti.brojRacuna +" je isti kao kod korisnika: " + item.ime);
                }
                else if (klijenti.emailKorisnik == item.emailKorisnik) 
                {
                    return Conflict("VEC POSTOJI UNESNI EMAIL");
                }

            }
            if (klijenti.lozinka.Length < 5)
                return BadRequest("Lozinka Mora biti duza");
            db.Klijenti.Add(klijenti);
            db.SaveChanges();
            return Ok(klijenti);    

        }

        [HttpPut]
        //MiJENJA SE ISKUCIVO AKO SE TOCNO NAVEDE KOJE AtRIBUTE ZELIMO PROMJENITI 
        public IActionResult Izmjeni(Klijenti klijenti) 
        {
            var db= new APIDbContext();

            Klijenti novo = db.Klijenti.Find(klijenti.KlijentiId);

            novo.korisnickoIme = klijenti.korisnickoIme;
            novo.adresa = klijenti.adresa;
            
            db.Klijenti.Update(novo);
            db.SaveChanges();

            return Ok(novo);

            

        }

        [HttpDelete("{kime}")]
        //BRISANJE PREKO OIBA, ODMAH SE BRiSU SVE UPLATE KOJE SU VEZANE ZA TAJ OIB
        public  IActionResult BrisanjeKlijenta(string kime) 
        {
            var db = new APIDbContext();

            Klijenti klijenti = db.Klijenti.FirstOrDefault(x=>x.korisnickoIme==kime);

            if(klijenti == null) 
            {
                return BadRequest("NAZALOST KORISNIK SA TIM OIBOM NE POSTOJI");
            }

            //else 
            //{
              
            //    var trans= db.Transakcije.ToList();
            //    foreach(var t in trans) 
            //    {
            //        if(t.OIB == oib) 
            //        {
                       
            //           db.Transakcije.Remove(t);
            //        }
            //    }

                db.Remove(klijenti);
                db.SaveChanges();
                return Ok("IZBRISANA TANSAKCIJA: "  );




            }



          

           


        
        //POKUSAJ UPDATE PREKO PUT
        //[HttpPut("{korisko}")]

        //public IActionResult IzmjenaOib(string korisnicko) 
        //{
        //    var db= new APIDbContext();

        //    Klijenti klijent = db.Klijenti.FirstOrDefault(x => x.korisnickoIme == korisnicko);

        //    if(klijent == null)
        //    {
        //        return BadRequest("korinsik niej pronaden");
        //    }

        //    else 
        //    {

        //    }


        //}

        [HttpGet("{korisnicko}")]
        public IActionResult Korisnicko(string  korisnicko)

        {
            var db = new APIDbContext();

                Klijenti zaposlenici = db.Klijenti.FirstOrDefault(x=>x.korisnickoIme==korisnicko);

            if (zaposlenici != null)
                return Ok(zaposlenici);

            return BadRequest("nema korsnika sa tim ID-em");

        }


    }
}
