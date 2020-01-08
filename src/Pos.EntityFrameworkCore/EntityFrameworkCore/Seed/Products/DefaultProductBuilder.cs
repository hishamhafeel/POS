using Pos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.EntityFrameworkCore.Seed.Products
{
    public class DefaultProductBuilder
    {
        private readonly PosDbContext _context;

        public DefaultProductBuilder(PosDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultProduct();
        }

        private void CreateDefaultProduct()
        {
            //Default product

            if (!_context.Products.Any())
            {
                var defaultProducts = new List<Product>
                {
                    new Product { ProductName="Soap", ProductDescription="This is a soap.", ProductQtyInStock=100.0M, ProductUnitPrice=50M},
                    new Product { ProductName="Cream", ProductDescription="This is a cream.", ProductQtyInStock=200.0M, ProductUnitPrice=250M},
                    new Product { ProductName="Shampoo", ProductDescription="This is a shampoo.", ProductQtyInStock=300.0M, ProductUnitPrice=200M},
                    new Product { ProductName="Perfume", ProductDescription="This is a perfume.", ProductQtyInStock=50.0M, ProductUnitPrice=500M}
                };

                _context.Products.AddRange(defaultProducts);
            }
        }
    }
}
