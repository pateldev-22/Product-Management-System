using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository_Layer.Data;
using Repository_Layer.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Repository_Layer.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public ProductRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public int GetTotalProductCount()
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Products";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                count = (int)command.ExecuteScalar();
                connection.Close();
            }

            return count;
        }
    }
}
