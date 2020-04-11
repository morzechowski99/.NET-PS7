using PS7.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PS7.DAL
{
    public class CategoryDB
    {
        private List<Category> categoryList;
        public List<Category> List()
        {
            return categoryList;
        }
        public void Load(string connectionString)
        {
            List<Category> categories = new List<Category>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_categoryList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = Int32.Parse(reader["Id"].ToString());
                    string shortname = reader["shortName"].ToString();
                    string longname = reader["longName"].ToString();
                    categories.Add(new Category
                    {
                        id = id,
                        shortname = shortname,
                        longname = longname,
                    });

                }
                reader.Close();

            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();

            }
            categoryList = categories;

        }
    }
}
