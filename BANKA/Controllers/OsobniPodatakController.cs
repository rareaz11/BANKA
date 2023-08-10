using BANKA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BANKA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsobniPodatakController : ControllerBase
    {
        [HttpGet]
        public IActionResult Dohvati()
        {
            var db = new APIDbContext();

            var list = db.OsobniPodatci.ToList();

            return Ok(list);




        }
        [HttpPost]

        public IActionResult DodavanjeOsobno(OsobniPodatci osobniPodatci)
        {


            if (ModelState.IsValid)
            {
                var db = new APIDbContext();

                var list =db.Zaposlenici.ToList();

                foreach (var item in list) 
                {
                    if(osobniPodatci.OIB==item.OIB || osobniPodatci.Email == item.email) 
                    {
                        return BadRequest("PODATCI SE PODUDARAJU SA DRUGIM KORISNIKOM PROVJERITE ISPAVNOST OIBA I EMAILA:");
                    } 

                   
                    
                }

                db.OsobniPodatci.Add(osobniPodatci);

                return Created("", db);
            }

            else
            {
                return BadRequest("Greska");
            }

        }

        [HttpPut]

        public IActionResult IzmjeniOsobne(OsobniPodatci osobni)
        {
            
            var db= new APIDbContext();

            OsobniPodatci podatci = db.OsobniPodatci.Find(osobni.OIB);

            podatci.Mobitel=osobni.Mobitel;
            podatci.Adresa = osobni.Adresa;
            podatci.DatumRodeanja = osobni.DatumRodeanja;
            podatci.Email= osobni.Email;
            var list =db.OsobniPodatci.ToList();    

            foreach(var item in list)
            {
                if (podatci.Email == item.Email) 
                {
                    return BadRequest("UNESEN EMAIL KOJI SE KORISTI KOD DRUGIH KORISNIKA");

                }
            }

            db.OsobniPodatci.Update(podatci);
            db.SaveChanges();   

            return Ok(podatci);




        }

       









    }

}


     

