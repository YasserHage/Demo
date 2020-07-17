using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Models;

namespace Demo.Repositories{

    public class MySqlProductRepository : IProductRepository
    {
        private readonly DemoContext _context;

        public MySqlProductRepository(DemoContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.products.ToList();
        }
        public Product GetProductById(int id)
        {
            return _context.products.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            // Do not apply
        }

        public void PartialUpdateProduct(Product product)
        {
            // Do not apply
        }

        public void DeleteProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.products.Remove(product);
        }
    }
}