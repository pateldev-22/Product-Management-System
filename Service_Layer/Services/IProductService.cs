using Repository_Layer.Entity;
using System.Collections.Generic;

namespace Service_Layer.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        int GetTotalProductCount();
    }
}
