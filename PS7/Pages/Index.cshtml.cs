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
        public IConfiguration _configuration { get; }
        public string lblInfoText;
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult OnGet()
        {
            return RedirectToPage("List");
            string myCompanyDB_connection_string =
           _configuration.GetConnectionString("myCompanyDB");
            SqlConnection con = new SqlConnection(myCompanyDB_connection_string);
            SqlCommand cmd = new SqlCommand("sp_productAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter name_SqlParam = new SqlParameter("@name", SqlDbType.VarChar,50);
            name_SqlParam.Value = "baton";
            cmd.Parameters.Add(name_SqlParam);
            SqlParameter price_SqlParam = new SqlParameter("@price", SqlDbType.Money);
            price_SqlParam.Value = 4.50;
            cmd.Parameters.Add(price_SqlParam);
            SqlParameter productID_SqlParam = new SqlParameter("@productID",
           SqlDbType.Int);
            productID_SqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(productID_SqlParam);
            con.Open();
            int numAff = cmd.ExecuteNonQuery();
            con.Close();
            lblInfoText += String.Format("Inserted <b>{0}</b> record(s)<br />", numAff);
            int productID = (int)cmd.Parameters["@productID"].Value;
            lblInfoText += "New ID: " + productID.ToString();
        }
    }
}
