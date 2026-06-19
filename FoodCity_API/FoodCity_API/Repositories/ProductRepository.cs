using FoodCityProductApi.Entities;
using Microsoft.Data.SqlClient;
using FoodCityProductApi.IRepositories;

namespace FoodCityProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("FoodCityDb");
        }

        public List<Product> GetAllProducts()
        {

            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                conn.Open();

                string query = "SELECT * FROM Products";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        ProductName = reader["ProductName"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    };

                    products.Add(product);
                }
            }

            return products;

        }

        public Product? GetProductById(int productId)
        {
            Product? product = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Products WHERE ProductId = @ProductId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new Product
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        ProductName = reader["ProductName"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    };
                }
            }
            return product;
        }

        public int CreateProduct(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Products (ProductName, Price, Quantity) VALUES (@ProductName, @Price, @Quantity) SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);

                int newProductId = Convert.ToInt32(cmd.ExecuteScalar());

                return newProductId;
            }
        }



    }
}
