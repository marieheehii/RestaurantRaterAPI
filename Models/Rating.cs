using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class Rating
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [ForeignKey(nameof(Resturaunt))]
        public int  RestarauntID { get; set; }
        [Required]
        public double Score { get; set; }

    }
