using BANKA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BANKA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransakcijeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var db = new APIDbContext();



            var list = db.Transakcije.ToList();

            return Ok(list);
        }

        [HttpPut]

        public IActionResult OsvjdziTransakciju(Transakcije transakcije)
        {

            var db= new APIDbContext();

            Transakcije transakcije1 =db.Transakcije.FirstOrDefault(x=>x.OIB==transakcije.OIB);
            if (transakcije1 == null)
            {
                return BadRequest("NE POSTOJI TRANSAKCIJA SA TIM OIBOM");
            }
            else
            {
                
               var lista = db.Klijenti.ToList();
                foreach (var item in lista) 
                {
                    if (item.OIB == transakcije1.OIB) 
                    {
                        if (item.brojRacuna == transakcije1.brZiroRacu)
                        {
                            Klijenti klijenti2 = db.Klijenti.Find(item.KlijentiId);
                            transakcije1.iznos = transakcije.iznos;
                            klijenti2.stanjeRacuna += transakcije.iznos;
                            db.SaveChanges();
                            return Ok(klijenti2.ime);
                        }

                        else 
                        {
                            return BadRequest("OIB JE TOCAN ALI BROJ RACUNA NIJE: " + transakcije.brZiroRacu);
                        }

                    }
                }

                return BadRequest("pogreska ne postoji klijent sa tim oibom");
              
            }
            
        }

        [HttpPost]

        public IActionResult DoodajTransakciju(Transakcije transakcije) 
        {

            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
              
                var lista = db.Klijenti.ToList();   
                
                foreach (var item in lista) 
                {
                    if (transakcije.OIB == item.OIB) 
                    {
                        if (transakcije.brZiroRacu == item.brojRacuna)
                        {
                            Klijenti klijenti = db.Klijenti.Find(item.KlijentiId);

                            klijenti.stanjeRacuna += transakcije.iznos;


                            db.Transakcije.Add(transakcije);
                            db.SaveChanges();
                            return (Ok("sad je  stanje racuna : " + klijenti.stanjeRacuna));

                        }
                        else 
                        {
                            return BadRequest("ne postoji taj ziro racun");
                        }
                            
                    }
                }

                
                    return BadRequest("NE POSTOJI TAJ OIB");
                

               
            }

            else
                return BadRequest();    

        }

        [HttpDelete("{Racun}")]

        public IActionResult IzbrisiUplatu(string racun)
        {

            var db = new APIDbContext();
            Transakcije transakcije=db.Transakcije.FirstOrDefault(x=>x.brZiroRacu==racun);

            if (transakcije == null) 
            {
                return BadRequest("NE POSTOJI TAJ BANKOVNI RACUN");
            }

            else 
            {
                Klijenti klijenti1=db.Klijenti.FirstOrDefault(x=>x.brojRacuna==racun);
              

                klijenti1.stanjeRacuna -= transakcije.iznos;

                db.Remove(transakcije);
                db.SaveChanges();
                return Ok(transakcije);
            }


        }
    }

   
}
