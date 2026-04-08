using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using ProductManagement.Models;

namespace ProductManagement.Data
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            // Load connection string from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // 1. Insert Product using stored procedure
        public void InsertProduct(string productName, string category, decimal price)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Using SqlParameter to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Price", price);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("✅ Product inserted successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inserting product: {ex.Message}");
            }
        }

        // 2. Get All Products using stored procedure
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Category = reader["Category"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"])
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error retrieving products: {ex.Message}");
            }

            return products;
        }

        // 3. Update Product using stored procedure
        public void UpdateProduct(int productId, string productName, string category, decimal price)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Using SqlParameter to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Price", price);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Console.WriteLine("✅ Product updated successfully!");
                        else
                            Console.WriteLine("❌ Product not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating product: {ex.Message}");
            }
        }

        // 4. Delete Product using stored procedure
        public void DeleteProduct(int productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Using SqlParameter to prevent SQL Injection
                        cmd.Parameters.AddWithValue("@ProductId", productId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Console.WriteLine("✅ Product deleted successfully!");
                        else
                            Console.WriteLine("❌ Product not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting product: {ex.Message}");
            }
        }

        // Check if product exists
        public bool ProductExists(int productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Products WHERE ProductId = @ProductId", conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}