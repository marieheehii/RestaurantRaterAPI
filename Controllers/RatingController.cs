using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
    public class RatingController : Controller
    {
        private readonly ILogger<RatingController> _logger;
        private RestaurauntDBContext _context;
        public RatingController(ILogger<RatingController> logger, RestaurauntDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RateRestaurant([FromForm] RatingEdit model)
        {
            if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _context.Ratings.Add(new Rating(){
            Score = model.Score,
            RestarauntID = model.RestarauntID,
        });
        await _context.SaveChangesAsync();
        return Ok();
        }
    }
