using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    class ProductRepository : RepositoryBase<StoreProjectEntities>
    {
        public ProductRepository()
           : base(new StoreProjectEntities())
        {
        }

        public Product GetProduct(int productId)
        {
            return GetFirst<Product>(pr => pr.ProductId == productId,"products_Photo","products_Price");
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return GetAll<Product>();
        }


        public void AddProduct(Product product)
        {
            Add(product);
            SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            var dbProducts = GetFirst<Product>(pr => pr.ProductId == product.ProductId);
            Remove(dbProducts);
        }

        public void UpdateProduct(Product product)
        {
            var dbProducts = GetFirst<Product>(pr => pr.ProductId == product.ProductId);
            dbProducts.Name = product.Name ?? dbProducts.Name;
            dbProducts.Description = product.Description ?? dbProducts.Description;
            dbProducts.ProductsTypeId = product.ProductsTypeId ?? dbProducts.ProductsTypeId;
  
        }

    }
}
