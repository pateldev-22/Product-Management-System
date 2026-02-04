using Repository_Layer.Entity;
using Repository_Layer.Repository;
using System.Collections.Generic;

namespace Service_Layer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public bool AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                return false;

            if (product.Price <= 0)
                return false;

            _productRepository.AddProduct(product);
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0)
                return false;

            _productRepository.UpdateProduct(product);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return false;

            _productRepository.DeleteProduct(id);
            return true;
        }

        public int GetTotalProductCount()
        {
            return _productRepository.GetTotalProductCount();
        }
    }
}
