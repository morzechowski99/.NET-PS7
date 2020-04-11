using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PS7.Models
{
    public class Category
    {

        [Display(Name = "Id")]
        [Required]
        public int id { get; set; } 
        [Display(Name = "krótka nazwa kategorii")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(20)]
        public string shortname { get; set; }
        [Display(Name = "długa nazwa kategorii")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(100)]
        public string longname { get; set; }
        
    }
}
