using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectData.repositories
{
    class ProfileRepository : RepositoryBase<StoreProjectEntities>
    {
        public ProfileRepository()
            : base(new StoreProjectEntities())
        {
        }

        public Profil_User GetProfileUser(int profil_userId)
        {
            return GetFirst<Profil_User>(pu => pu.ProfilUserId == profil_userId, "AspNetUser","Address");
        }

        public void RemoveProfilUser(Profil_User profil_User)
        {   var dbProfil_User = GetFirst<Profil_User>(pu => pu.ProfilUserId == profil_User.ProfilUserId);
            dbProfil_User.Active = false;
            SaveChanges();
        }

        public void AddProfilUser(Profil_User profil_User)
        {
            Add(profil_User);
            SaveChanges();
        }

        public void UpdateProfilUser(Profil_User profil_User)
        {
            var dbProfil_User = GetFirst<Profil_User>(pu => pu.ProfilUserId == profil_User.ProfilUserId);
                       

            //dbProfil_User.AspUserId = profil_User.AspUserId;
            dbProfil_User.First_Name = profil_User.First_Name ?? dbProfil_User.First_Name;
            dbProfil_User.Last_Name = profil_User.Last_Name ?? dbProfil_User.Last_Name;
            dbProfil_User.Phone_Number = profil_User.Phone_Number ?? dbProfil_User.Phone_Number;
            SaveChanges();
        }

    }
}
