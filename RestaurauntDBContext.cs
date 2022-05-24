using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI.Models;

namespace RestaurantRaterAPI
{
    public class RestaurauntDBContext : DbContext
    {
        public RestaurauntDBContext(DbContextOptions<RestaurauntDBContext> options) : base(options) {}
        public DbSet<Resturaunt> Resturaunts {get; set;}
        public DbSet<Rating> Ratings {get; set;}
    }
}