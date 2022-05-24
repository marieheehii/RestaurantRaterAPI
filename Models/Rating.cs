using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Models
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        [ForeignKey(nameof(Resturaunt))]
        public string  RestarauntID { get; set; }
        public Resturaunt Resturaunt {get; set;}

    }
}