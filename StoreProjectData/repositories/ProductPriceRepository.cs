using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    class ProductPriceRepository : RepositoryBase<StoreProjectEntities>
    {
        public ProductPriceRepository()
          : base(new StoreProjectEntities())
        {
        }

        public Products_Price GetProductPrice(int productId)
        {
            return GetFirst<Products_Price>(pr => pr.ProductId == productId);
        }

        public void AddProductPrice(Products_Price price)
        {
            Add(price);
            SaveChanges();
        }

        public void RemoveProductPhoto(Products_Price Product_price)
        {
            var dbProductPrice = GetFirst<Products_Price>(pr => pr.ProductId == Product_price.ProductId && pr.ProductPriceId == Product_price.ProductPriceId);
            Remove(dbProductPrice);
            SaveChanges();
        }

        public void UpdateProductPhoto(Products_Price Product_price)
        {
            var dbProductPrice = GetFirst<Products_Price>(pr => pr.ProductId == Product_price.ProductId && pr.ProductPriceId == Product_price.ProductPriceId);
            dbProductPrice.Price = Product_price.Price ?? dbProductPrice.Price;
            dbProductPrice.Available_Date = Product_price.Available_Date ?? dbProductPrice.Available_Date;
            dbProductPrice.Available_Date = Product_price.Available_Date;
            SaveChanges();
        }
    }
}
