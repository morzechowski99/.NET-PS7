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
    public class EditModel : MyPageModel
    {

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty]
        public Product product { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<Category> categories { get; set; }
        public EditModel(IConfiguration configuration) : base(configuration)
        {


        }
        public void OnGet()
        {
            LoadCategories();
            categories = categoryDB.List();
            product = GetProductById(id);

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                categories = categoryDB.List();
                return Page();
            }
            product.id = id;
            ChangeProduct(product);
            return RedirectToPage("List");
        }
    }
    
}