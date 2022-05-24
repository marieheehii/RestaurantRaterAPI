using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestaurantRaterAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace RestaurantRaterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurauntController: Controller
    {
        private RestaurauntDBContext _context;
        public RestaurauntController(RestaurauntDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostRestaurauny([FromForm] RestaurauntEdit model) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                 _context.Resturaunts.Add(new Resturaunt()
                {
                    Name = model.Name,
                    Location = model.Location,
                }
                );
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRestauraunts()
        {
            var restauraunts = await _context.Resturaunts.ToListAsync();
            return Ok(restauraunts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRestaurauntByID(int id)
        {
            var restauraunt = await _context.Resturaunts.FindAsync(id);
            if(restauraunt == null)
            {
                return NotFound();
            }
            return Ok(restauraunt);
        }
    }
}