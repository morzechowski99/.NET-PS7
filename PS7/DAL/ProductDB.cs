using Microsoft.Extensions.Configuration;
using PS7.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PS7.DAL
{
    public class ProductDB
    {
        private List<Product> productList;
        public List<Product> List()
        {
            return productList;
        }
        public void Load(string connectionString)
        {
            List<Product> products = new List<Product>(); 
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_productList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {

                    int id = Int32.Parse(reader["Id"].ToString());
                    string name = reader["name"].ToString();
                    decimal price = Decimal.Parse(reader["price"].ToString());
                    string category = reader["longName"].ToString();
                    products.Add(new Product { id = id, name = name, price = price,
                        category= category });

                }
                reader.Close();
            }
            catch(Exception e)
            {

            }
            finally
            {
                 con.Close();
               
            }
            productList = products;
            


        }
        
        public void Delete(int id, string connectionString)
        {
           
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_productDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
            cmd.Parameters["@ProductID"].Value = id;
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
        public void Create(Product p, string connectionString)
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_productAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NChar,20));
            cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.Money));
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters["@name"].Value = p.name;
            cmd.Parameters["@price"].Value = p.price;
            cmd.Parameters["@CategoryId"].Value = p.categoryID;
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
        public Product GetProduct(int id, string connectionString)
        {
            
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_productById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
            cmd.Parameters["@ProductID"].Value = id;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Product p;
                reader.Read();
                if (reader.HasRows == true)
                {
                    int idd = Int32.Parse(reader["Id"].ToString());
                    string name = reader["name"].ToString();
                    decimal price = Decimal.Parse(reader["price"].ToString());
                    string category = reader["longName"].ToString();
                    p = new Product { id = id, name = name, price = price,category=category };
                    reader.Close();
                    
                    return p;
                }
            }
            catch(Exception e)
            {

            }
            finally
            {
                con.Close();
            }
            return null;
        }
        public void Change(Product p, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_productChange", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NChar, 20));
            cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.Money));
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            cmd.Parameters["@name"].Value = p.name;
            cmd.Parameters["@price"].Value = p.price;
            cmd.Parameters["@CategoryId"].Value = p.categoryID;
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

