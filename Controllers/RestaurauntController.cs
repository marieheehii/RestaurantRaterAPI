using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


    [ApiController]
    [Route("[controller]")]
    public class RestaurauntController: Controller
    {
        private RestaurauntDBContext _context;
        public RestaurauntController(RestaurauntDBContext context)
        {
            _context = context;
        }
        public virtual List<Rating> Ratings {get; set;} = new List<Rating>();
        public double AverageRating
        {
            get
            {
                if(Ratings.Count == 0)
                {
                    return 0;
                }
                double total = 0.0;
                foreach (Rating rating in Ratings)
                {
                    total += rating.Score;
                }
                return total / Ratings.Count;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostRestauraunt([FromForm] RestaurauntEdit model) 
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
            var restauraunt = await _context.Resturaunts.Include(r => r.Rating).ToListAsync();
            List<RestaurantListItem> restaurantList = Resturaunts.Select(r=> new RestaurantListItem(){
                ID = r.ID,
                Name = r.Name,
                Location = r.Location,
                AverageScore = r.AverageScore,
            }).ToList();
            return Ok(restaurantList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRestaurauntByID(int id)
        {
            var restauraunt = await _context.Resturaunts.Include(r => r.Rating).FirstOrDefaultAsync(r => r.ID == id);
            if(restauraunt == null)
            {
                return NotFound();
            }
            return Ok(restauraunt);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRestauraunt([FromForm] RestaurauntEdit model, [FromRoute] int id)
        {
            var oldRestauraunt = await _context.Resturaunts.FindAsync(id);
            if(oldRestauraunt == null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(!string.IsNullOrEmpty(model.Name))
            {
                oldRestauraunt.Name = model.Name;
            }
            if(!string.IsNullOrEmpty(model.Location))
            {
                oldRestauraunt.Location = model.Location;
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRestauraunt([FromRoute] int id)
        {
            var restauraunt = await _context.Resturaunts.FindAsync(id);
            if(restauraunt == null)
            {
                return NotFound();
            } 
            _context.Resturaunts.Remove(restauraunt);
            await _context.SaveChangesAsync();
            return Ok(); 

        }

    }
