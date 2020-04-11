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
    public class ListModel : MyPageModel
    {
        public List<Product> products;
        [BindProperty]
        public int id { get; set; }
        public void OnGet()
        {
            LoadDB();
            products = productDB.List();
        }
        public ListModel(IConfiguration configuration) : base(configuration)
        {


        }
        public IActionResult OnPost()
        {


            return RedirectToPage("Edit", new { id = id });
        }
        public IActionResult OnPostDelete()
        {
            LoadDB();
            DeleteProduct(id);

            return RedirectToPage("List");
        }
    }

}