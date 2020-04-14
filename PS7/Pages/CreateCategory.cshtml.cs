using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS7.Models;

namespace PS7.Pages
{
    public class CreateCategoryModel : CategoryModel
    {
        [BindProperty]
        public Category newCategory { get; set; }
        public void OnGet()
        {
            
        }
        public CreateCategoryModel(IConfiguration configuration) : base(configuration)
        {


        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CreateCategory(newCategory);

            return RedirectToPage("Categories");
        }
    }
}