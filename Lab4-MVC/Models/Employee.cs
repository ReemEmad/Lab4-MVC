using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab4_MVC.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Range(1200, 5000)]
        public int salary { get; set; }

        [MaxLength(50)]
        public string address { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}