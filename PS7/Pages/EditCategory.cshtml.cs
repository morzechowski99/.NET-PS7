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
    public class EditCategoryModel : CategoryModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty]
        public Category category { get; set; }
      
        public EditCategoryModel(IConfiguration configuration) : base(configuration)
        {


        }
        public void OnGet()
        {
            category = GetCategoryById(id);

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
               
                return Page();
            }
            category.id = id;
            ChangeCategory(category);
            return RedirectToPage("Categories");
        }
    }
}