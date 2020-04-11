using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS7.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS7.Models
{
    
    public class MyPageModel : PageModel
    {
        public ProductDB productDB;
        public CategoryDB categoryDB;
        private string connectionString;
        public IConfiguration _configuration { get; set; }
        public MyPageModel(IConfiguration configuration)
        {
            _configuration = configuration;
            productDB = new ProductDB();
            categoryDB = new CategoryDB();
            connectionString = _configuration.GetConnectionString("myCompanyDB");
        }
        public void LoadDB()
        {
            productDB.Load(connectionString);
        }
        public void LoadCategories()
        {
            categoryDB.Load(connectionString);
        }
        public void DeleteProduct(int id)
        {
            productDB.Delete(id, connectionString);
        }
        public void CreateProduct(Product p)
        {
            productDB.Create(p, connectionString);
        }
        public Product GetProductById(int id)
        {
            return productDB.GetProduct(id, connectionString);
        }
        public void ChangeProduct(Product p)
        {
            productDB.Change(p, connectionString);
        }
    }
}
