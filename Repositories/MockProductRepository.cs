using System.Collections.Generic;
using Demo.Models;

namespace Demo.Repositories{
    public class MockProductRepository : IProductRepository{
        
        public IEnumerable<Product> GetProducts(){
            var products = new List<Product>{
                new Product{id=0, name="Copo plastico", description="Copo 300ml"},
                new Product{id=1, name="Sacola", description="Sacola 15 x 30"},
                new Product{id=2, name="Saco de pão", description="Saco de papel"}
            };
            return products;
        }

        public Product GetProductById(int id){
            return new Product{id=0, name="Copo plastico", description="Copo 300ml"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void CreateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void PartialUpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}