using BANKA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BANKA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZaposleniciController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get() 
        {

            var db = new APIDbContext();

            var list = db.Zaposlenici.ToList();
          
            if (list == null)
                return NotFound();
            else
                return Ok(list);

        }
        [HttpGet("{Id}")]
        public IActionResult Get(int id)

        {
            var db = new APIDbContext();

            Zaposlenici zaposlenici = db.Zaposlenici.Find(id);

            if (zaposlenici != null)
                return Ok(zaposlenici);
            return BadRequest("nema korsnika sa tim ID-em");

        }

        //[HttpGet("{ime}/{prezime}")]

        //public IActionResult DohavtiIme(string ime, string prezime)
        //{
        //    var db = new APIDbContext();

        //    Zaposlenici zaposlenici = db.Zaposlenici.FirstOrDefault(x => x.Ime == ime);

        //    if (zaposlenici != null)
        //        return Ok(zaposlenici);

        //    else
        //        return BadRequest("Nema korisnika sa tim imenom");
        //}
        ////post je za dodavanje
        //[HttpGet("{ime}/{Prezime}/{kor}/{email}")]
        //public IActionResult Dodaj(string ime, string prezime, string kor, string email)
        //{
        //    var db = new APIDbContext();

        //    Zaposlenici zaposlenici = new Zaposlenici();

        //    zaposlenici.Ime = ime;
        //    zaposlenici.Prezime = prezime;
        //    zaposlenici.KorisnickoIme = kor;
        //    zaposlenici.email = email;
        //    db.Zaposlenici.Add(zaposlenici);
        //    db.SaveChanges();

        //    return Ok(db.Zaposlenici);


        //}
        [HttpPost]
        public IActionResult Dodavanje(Zaposlenici zaposlenici)
        {
            string sifra = "";
            Random random = new Random();

            string a = "abcdefghijklmnoprstxyzABCDEFGHIJKLMNOPRSTYXZWQ0123456789/*#$%";



            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(0, 61);
                sifra += a[x];

            }
            zaposlenici.lozinka = sifra;

            



            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
                var list = db.Zaposlenici.ToList();
                
                   

                if(zaposlenici.OIB==0) 
                {
                    return BadRequest("Oib ima oznaku 0 ili ima razliciti broj brojeva " +
                        "Napomena treba imati 11 brojeva");
                }
            
                foreach (var item in list)
                {
                    if (item.KorisnickoIme == zaposlenici.KorisnickoIme)
                    {
                        return BadRequest("KORISNICKO IME VEC POSTOJI");
                    }
                    else if (item.OIB == zaposlenici.OIB)
                    {
                        return BadRequest("NE SMIJU BIT 2 ISTA OIBA");
                    }

                    else if (item.email == zaposlenici.email)
                    {
                        return BadRequest("NE SMIJIU BIT 2 ISTA OIBA");
                    }

                }
                db.Zaposlenici.Add(zaposlenici);
                db.SaveChanges();

                return Created("", zaposlenici);
            }
            else
                return BadRequest("GRESKA");
        }

        [HttpPut]

        public IActionResult IzmjeniOsobnePodatke(Zaposlenici zaposlenici)
        {
            if (ModelState.IsValid)
            {

                var db = new APIDbContext();
                Zaposlenici novo = db.Zaposlenici.Find(zaposlenici.ZaposleniciId);
                novo.Ime = zaposlenici.Ime;
                novo.Prezime = zaposlenici.Prezime;
                novo.email = zaposlenici.email;




                db.SaveChanges();


                return Ok(zaposlenici);


            }
            else
                return BadRequest("Pogreska");


        }
        [HttpDelete("{a}")]

        public IActionResult Izbrisi(int a)
        {
            if (ModelState.IsValid)
            {
                var db = new APIDbContext();

                Zaposlenici zaposlenici1 = db.Zaposlenici.Find(a);


                if (zaposlenici1 == null)
                {
                    return BadRequest("nema korisnika sa tim imenom");
                }
                else 
                {

                    db.Zaposlenici.Remove(zaposlenici1);
                    db.SaveChanges();


                    return Ok(zaposlenici1.KorisnickoIme+" je obrisan");
                }

              
            }




            else
                return BadRequest("ne postoji taj korisnik");

        }

        //[HttpDelete("{ime}")]

        //public IActionResult IzbrisiZaposlenika(string ime)
        //{
        //    var db = new APIDbContext();

        //    Zaposlenici izbrisi = db.Zaposlenici.Where(x => x.Ime == ime).FirstOrDefault();

        //    if (izbrisi != null)

        //    {
        //        db.Remove(izbrisi);

        //        db.SaveChanges();

        //        return Ok(ime);
        //    }

        //    else
        //        return BadRequest("ne postoji zaposlenik sa tim imenom");

        //}


    }
}
