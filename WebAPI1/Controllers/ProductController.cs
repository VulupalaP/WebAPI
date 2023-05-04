using WebAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace MYFirstWebAPI1.Controllers
{
    public class ProductController : ApiController
    {
        ProductDBEntities productDBEntities = new ProductDBEntities();
        Product product = new Product();
        // This method would return the list of products
        [HttpGet]
        public IEnumerable<Product> GetProductsList()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = productDBEntities.Products.ToList();
            }
            catch(Exception ex)
            {
                StreamWriter streamWriter = new StreamWriter(@"D:\Error.txt");
                streamWriter.WriteLine(ex.Message);
                streamWriter.WriteLine(ex.StackTrace);
                streamWriter.Close();

            }
            return products;
        }

        // This method would the product based on the id

        [HttpGet]
        public Product GetProductById(int id)
        {
            product = productDBEntities.Products.Find(id);
            return product;
        }

        // This method would create the product
        [HttpPost]
        public string CreateProduct(Product prod)
        {
            product.ProductName = prod.ProductName;
            product.ProductPrice = prod.ProductPrice;
            productDBEntities.Products.Add(product);
            productDBEntities.SaveChanges();
            return "The product is created";
        }

        // This method would update the product
        [HttpPut]
        public string UpdateProduct(Product prod)
        {
            
                product = productDBEntities.Products.Find(prod.ProductId);
                product.ProductName = prod.ProductName;
                product.ProductPrice = prod.ProductPrice;
                productDBEntities.SaveChanges();
                return "The product is updated"; 
           
           
        }

        // This method would delete the product
        [HttpDelete]
        public string DeleteProduct(int id)
        {
            product = productDBEntities.Products.Find(id);
            productDBEntities.Products.Remove(product);
            productDBEntities.SaveChanges();
            return "The product is deleted";
        }


    }
}
