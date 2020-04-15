using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PS7.Pages
{
    public class IndexModel : PageModel
    {
      
      
        public IActionResult OnGet()
        {
            return RedirectToPage("List");
           
        }
    }
}
