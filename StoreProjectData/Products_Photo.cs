//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreProjectData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products_Photo
    {
        public int Id_Products_Photo { get; set; }
        public int Id_Products { get; set; }
        public string Url_Photo { get; set; }
    
        public virtual Products Products { get; set; }
    }
}
