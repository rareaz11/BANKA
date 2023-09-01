using BANKA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BANKA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankomatController : ControllerBase
    {
        [HttpGet]
        public IActionResult Popis() 
        {
            var db = new APIDbContext();

            var list = db.Bankomatis.ToList();

            return Ok(list);

           

        }
        [HttpGet("{grad}")]

        public IActionResult PoGradu(string grad) 
        {
            var db=new APIDbContext();

            var bankomat = db.Bankomatis.FirstOrDefault(x => x.grad ==grad);
            if (bankomat == null) 
            {
                return BadRequest("Bankomat nemamo u tom gradu");
            }
            else 
            {
                return Ok(bankomat);
            }

        }

        [HttpPost]

        public IActionResult Dodaj(Bankomati bankomati) 
        {
            var db=new APIDbContext();  
            
            var list= db.Bankomatis.ToList();

            foreach (var item in list) 
            {
                if (item.adresa == bankomati.adresa)
                {
                    return BadRequest("grska adresa ista");
                }
               
            }

            db.Bankomatis.Add(bankomati);
            db.SaveChanges();   
            return Ok(bankomati);  
          

        }

        [HttpPut]

        public IActionResult Izmjena(Bankomati bankomati) 
        {var db= new APIDbContext();
            Bankomati bankomati1 = db.Bankomatis.FirstOrDefault(x=>x.grad==bankomati.grad);
            var list =db.Bankomatis.ToList();

            foreach(var item in list) 
            {
                if(item.adresa == bankomati.adresa) 
                {
                    return BadRequest();
                }
            }

            bankomati1.adresa = bankomati.adresa;
            
            //if (bankomati == null) 
            //{
            //    return BadRequest();    

            //}

            //else 
            //{
            //    foreach (var item in list)
            //    {
            //        if(item.adresa == bankomati.adresa) 
            //        {
            //            return BadRequest();
            //        }

            //    }
            //}

            //bankomati1.adresa = bankomati.adresa;
            
            db.Bankomatis.Update(bankomati1);
            db.SaveChanges();
            return Ok(bankomati1);

        }
        [HttpDelete("{adresa}")]
        
        public IActionResult Izbrisi(string adresa) 
        {
            var db=new APIDbContext();  

            var bankomati = db.Bankomatis.FirstOrDefault(x=>x.adresa==adresa);
            if(bankomati == null) 
            {
                return NotFound("ne postoji bankomat sa tom adresom");  
            }

            else 
            {
                db.Remove(bankomati);
                db.SaveChanges();
                return Ok("Izbrisan");
            
            }
        }

    }
}
