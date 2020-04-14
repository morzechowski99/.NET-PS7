using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PS7.Models
{
    public class Product
    {
        [Display(Name = "Id")]
        [Required]
        public int id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(50,ErrorMessage = "Wartość za długa")]
        public string name { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Range(0, Double.MaxValue, ErrorMessage = "Cena musi być dodatnia")]
        public decimal price { get; set; }
        
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        [Range(1,Double.MaxValue)]
        public int categoryID { get; set; }
        [Display(Name = "Kategoria")]
        public string category { get; set; }
    }
}
