using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PS7.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS7.Models
{
    public class CategoryModel : PageModel
    {
        public CategoryDB categoryDB;
        private string connectionString;
        public IConfiguration _configuration { get; set; }
        public CategoryModel(IConfiguration configuration)
        {
            _configuration = configuration;
            categoryDB = new CategoryDB();
            connectionString = _configuration.GetConnectionString("myCompanyDB");
        }
        public void LoadCategories()
        {
            categoryDB.Load(connectionString);
        }public void CreateCategory(Category p)
        {
            categoryDB.Create(p, connectionString);
        }
        public void Delete(int id)
        {
            categoryDB.Delete(id, connectionString);
        }
        
        public Category GetCategoryById(int id)
        {
            return categoryDB.GetCategory(id, connectionString);
        }
        
        public void ChangeCategory(Category p)
        {
            categoryDB.Change(p, connectionString);
        }
    }
}
