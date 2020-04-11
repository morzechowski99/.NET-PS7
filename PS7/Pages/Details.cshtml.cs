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
   
        public class DetailsModel : MyPageModel
        {
            [BindProperty]
            public Product product { get; set; }
            public DetailsModel(IConfiguration configuration) : base(configuration)
            {


            }
            public void OnGet()
            {
                product = GetProductById(Int32.Parse(Request.Query["id"]));

            }

        }
    
}