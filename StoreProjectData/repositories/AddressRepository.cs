using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    class AddressRepository : RepositoryBase<StoreProjectEntities>
    {
        public AddressRepository()
            : base(new StoreProjectEntities())
        {
        }


        public IEnumerable<Address> GetAdress(int profil_userId)
        {
            return GetAll<Address>(ad => ad.ProfilUserId == profil_userId);
        }

        public void RemoveAddress(Address address)
        {
            var dbAdress = GetFirst<Address>(ad => (ad.ProfilUserId == address.ProfilUserId) && (ad.AdressId == address.AdressId) );
            Remove(dbAdress);
            SaveChanges();
        }

        public void AddProfilUser(Address address)
        {
            Add(address);
            SaveChanges();
        }

        public void UpdateProfilUser(Address address)
        {
            var dbAddress = GetFirst<Address>(ad => ad.ProfilUserId == address.ProfilUserId);

            dbAddress.Street = address.Street ?? dbAddress.Street;
            dbAddress.Number = address.Number ?? dbAddress.Number;
            dbAddress.Country = address.Country ?? dbAddress.Country;
            dbAddress.City = address.City ?? dbAddress.City;
            dbAddress.Postal_Code = address.Postal_Code;

            //dbProfil_User.AspUserId = profil_User.AspUserId;
           
            SaveChanges();
        }


    }
}
