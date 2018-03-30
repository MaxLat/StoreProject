using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    class SaleRepository : RepositoryBase<StoreProjectEntities>
    {
        public SaleRepository()
            : base(new StoreProjectEntities())
        {
        }

        public IEnumerable<Sale> GetSale(int profil_userId)
        {
            return GetAll<Sale>(sa => sa.ProfilUserId == profil_userId);
        }

       
        public IEnumerable<Sale> GetAllSale()
        {
            return GetAll<Sale>();
        }

        public void AddSale(Sale sale)
        {
            Add(sale);
            SaveChanges();
        }


        public void RemoveSale(Sale sale)
        {
            var dbSale = GetFirst<Sale>(sa => sa.SaleId == sale.SaleId);
            Remove(dbSale);
        }

        public void UpdateSale(Sale sale)
        {
            var dbSale = GetFirst<Sale>(sa => sa.SaleId == sale.SaleId);
            dbSale.Date = sale.Date ?? dbSale.Date;
            

        }
    }
}
