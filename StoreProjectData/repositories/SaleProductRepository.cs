using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    class SaleProductRepository : RepositoryBase<StoreProjectEntities>
    {
        public SaleProductRepository()
            : base(new StoreProjectEntities())
        {
        }

        public IEnumerable<Sale_Product> GetSaleProduct(int SaleId)
        {
            return GetAll<Sale_Product>(sa => sa.SaleId == SaleId);
        }


        public IEnumerable<Sale_Product> GetAllSaleProduct()
        {
            return GetAll<Sale_Product>();
        }

        public void AddSaleProduct(Sale_Product sale_product)
        {
            Add(sale_product);
            SaveChanges();
        }


        public void RemoveSaleProduct(Sale_Product sale_product)
        {
            var dbSaleProduct = GetFirst<Sale_Product>(sa => sa.SaleId == sale_product.SaleId);
            Remove(dbSaleProduct);
        }


        public void UpdateSaleProduct(Sale_Product sale_product)
        {
            var dbSale = GetFirst<Sale_Product>(sa => sa.SaleId == sale_product.SaleId);
            dbSale.quantite = sale_product.quantite ?? dbSale.quantite;


        }


    }
}
