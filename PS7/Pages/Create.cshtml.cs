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
    public class CreateModel : MyPageModel
    {
        [BindProperty]
        public Product newProduct { get; set; }
        [BindProperty(SupportsGet =true)]
        public List<Category> categories { get; set; }
        public void OnGet()
        {
            LoadCategories();
            categories = categoryDB.List();
        }
        public CreateModel(IConfiguration configuration) : base(configuration)
        {
            

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                categories = categoryDB.List();
                return Page();
            }

            CreateProduct(newProduct);

            return RedirectToPage("List");
        }
    }
}