using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal:IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {

                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }
            };



             
            
            
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            var DeleteOne = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(DeleteOne);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> Getall()
        {
            return _products;
        }

        public List<Product> Getall(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void GetAllByCategories(int a)
        {
            foreach (var item in _products)
            {
              var kaan=  _products.Where(p => p.CategoryId == a).ToList();

                foreach (var c in kaan)
                {
                    Console.WriteLine(c.ProductName+" "+c.UnitsInStock);
                }

            }
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            var UpdateOne = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            UpdateOne.ProductName = product.ProductName;
            UpdateOne.ProductId = product.ProductId;
        }
    }
}
