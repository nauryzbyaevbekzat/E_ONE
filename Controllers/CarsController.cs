
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventum.One2.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController  : ControllerBase
    {
        EventumOneContext db;

        public CarsController(EventumOneContext context )
        {
            db = context;
         
        }


        [Authorize]
        [HttpGet]
        [Route("[action]", Name = "GetHColors")]
        public async Task<ActionResult<IEnumerable<HColor>>> GetHColors()
        {
            
            return await db.HColor.ToListAsync();
           
        }
        [HttpGet]
        [Route("[action]", Name = "GetCars")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        { 
            return await db.Car.ToListAsync();
        }

  
        [Authorize]
        [HttpPost]
        [Route("[action]", Name = "PostCar")]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            db.Car.Add(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }
        
       
        [Authorize]
        [HttpPut]
        [Route("[action]", Name = "PutCar")]
        public async Task<ActionResult<Car>> PutCar(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (!db.Car.Any(x => x.Id == car.Id))
            {
                return NotFound();
            }

            db.Car.Update(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }
        
        [Authorize]
        [HttpDelete("{id}")] 
        
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            Car car = db.Car.FirstOrDefault(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            db.Car.Remove(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }
    }
}
