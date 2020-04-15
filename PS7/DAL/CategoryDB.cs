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
        public void Create(Category p, string connectionString)
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_CategoryAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@shortname", SqlDbType.NChar, 20));
            cmd.Parameters.Add(new SqlParameter("@longname", SqlDbType.NChar,100));
            
            cmd.Parameters["@shortname"].Value = p.shortname;
            cmd.Parameters["@longname"].Value = p.longname;
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException exc)
            {

            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(int id, string connectionString)
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_categoryDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int));
            cmd.Parameters["@CategoryID"].Value = id;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException exc)
            {

            }
            finally
            {
                con.Close();
            }
        }
        public Category GetCategory(int id, string connectionString)
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_categoryById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CategoryID", SqlDbType.Int));
            cmd.Parameters["@CategoryID"].Value = id;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Category p;
                reader.Read();
                if (reader.HasRows == true)
                {
                    int idd = Int32.Parse(reader["Id"].ToString());
                    string shortname = reader["shortname"].ToString();
                    string longname = reader["longname"].ToString();
                   
                    p = new Category { id = id, shortname = shortname, longname=longname };
                    reader.Close();

                    return p;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }
            return null;
        }
        public void Change(Category p, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_categoryEdit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@shortname", SqlDbType.NChar, 20));
            cmd.Parameters.Add(new SqlParameter("@longname", SqlDbType.NChar, 20));
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            cmd.Parameters["@shortname"].Value = p.shortname;
            cmd.Parameters["@longname"].Value = p.longname;
            cmd.Parameters["@id"].Value = p.id;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException exc)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}
