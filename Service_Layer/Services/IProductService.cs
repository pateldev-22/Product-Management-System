using Repository_Layer.Entity;


namespace Service_Layer.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }

}
