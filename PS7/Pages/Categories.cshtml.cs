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
    public class CategoriesModel : CategoryModel
    {
        public List<Category> categories;
        [BindProperty]
        public int id { get; set; }
        public void OnGet()
        {
            LoadCategories();
            categories = categoryDB.List();
        }
        public CategoriesModel(IConfiguration configuration) : base(configuration)
        {


        }
        public IActionResult OnPost()
        {


            return RedirectToPage("EditCategory", new { id = id });
        }
        public IActionResult OnPostDelete()
        {
            LoadCategories();
            Delete(id);

            return RedirectToPage("Categories");
        }
    }
}