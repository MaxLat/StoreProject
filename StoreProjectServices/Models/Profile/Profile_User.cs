using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectServices.Models.Profile
{
    public class Profile_User
    {
        
        public int ProfilUserId { get; set; }
        public string AspUserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public Nullable<bool> Active { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
