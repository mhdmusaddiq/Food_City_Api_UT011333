using FoodCityProductApi.Entities;
using System.Collections.Generic;

namespace FoodCityProductApi.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int productId);
        int CreateProduct(Product product);
        bool PatchProduct(
            int productId,
            string? productName,
            decimal? price,
            int? quantity
            );
        bool IsProductNameExists(string productName);
    }
}
