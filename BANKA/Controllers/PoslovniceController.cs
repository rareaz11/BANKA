using BANKA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BANKA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoslovniceController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ispis() 
        {//radi
            var db = new APIDbContext();

            var lista = db.Poslovnice.ToList();

            return Ok(lista);
        }

        [HttpPost]

        public IActionResult Dodaj(Poslovnice poslovnice) 
        {//radi
            var db=new APIDbContext();  

            var list = db.Poslovnice.ToList();  

            foreach (var item in list) 
            {
                if(item.kontakt == "" || item.kontakt==poslovnice.kontakt || item.Adresa==poslovnice.Adresa) 
                {
                    return BadRequest("ne smije biti duplanje podataka ili je kontakt prazan");
                }
            }

            db.Poslovnice.Add(poslovnice);
            db.SaveChanges();
            return Ok(poslovnice);


        }

        [HttpPut]

        public IActionResult Izmjena(Poslovnice poslovnice) 
        {//radi

            var db =new APIDbContext();
            var poslovnica1= db.Poslovnice.FirstOrDefault(x => x.Adresa ==poslovnice.Adresa);
            if (poslovnica1 == null) 
            {
                return NotFound();  
            }
            else 
            {
                poslovnica1.kontakt = poslovnice.kontakt;
                poslovnica1.mjesto = poslovnice.mjesto; 

                db.Poslovnice.Update(poslovnica1);
                db.SaveChanges();
                return Ok("promjena: " + poslovnica1);
            }
            //var poslovnice1 = db.Poslovnice.Find(poslovnice.PoslovnicaId);
            //var list= db.Poslovnice.ToList();
            //if (poslovnice1 == null)
            //{
            //    return BadRequest("ne postoji ta poslovnica");
            //}
            //foreach (var item in list)
            //{
            //    if (item.Adresa == poslovnice.Adresa)
            //    {
            //        return BadRequest("podaravanje podataka ");
            //    }




            //}
            //poslovnice1.Adresa = poslovnice.Adresa; 
            //poslovnice1.ZaposlenikID = poslovnice.ZaposlenikID;
       

        }

        [HttpDelete("{Id}")]

        public IActionResult Delete(int id) 
        {//radi

            var db=new APIDbContext();  

           var poslovnica = db.Poslovnice.Find(id);    
            if (poslovnica == null) 
            {
                return NotFound("ne psotoji ta poslovnica");
            }

            else 
            {

                db.Poslovnice.Remove(poslovnica);
                db.SaveChanges();
                return Ok("obrisan poslovnica: " +  poslovnica.PoslovnicaId);
            }

        }
        [HttpGet("{adresa}")]

        public IActionResult PoAdresi(string adresa)
        {
            var db = new APIDbContext();    

            var poslovnica= db.Poslovnice.FirstOrDefault(x=>x.Adresa==adresa);
            if(poslovnica == null) 
            {
                return NotFound();
            }

            else 
            {
                return Ok(poslovnica);
            }
        }

       
    }
}
