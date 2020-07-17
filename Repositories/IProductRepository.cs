using System.Collections.Generic;
using Demo.Models;

namespace Demo.Repositories{
    public interface IProductRepository{

        bool SaveChanges();
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void PartialUpdateProduct(Product product);
        void DeleteProduct(Product product);

    }
}