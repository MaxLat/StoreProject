using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreProjectServices.Contracts;

namespace StoreProjectServices.Services
{
    class ProfileService : IProfileService
    {
        Profil_User GetProfileUser(int profil_userId);
    }
}
