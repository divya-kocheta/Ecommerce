//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserReg_Table
    {
        public int userID { get; set; }
        public string fullName { get; set; }
        public string Email { get; set; }
        public long MobNo { get; set; }
        public string Ur_Pass { get; set; }
        public string Gender { get; set; }
        public string Addres { get; set; }
        public Nullable<int> Admin_Fk_ID { get; set; }
    
        public virtual AdminDetails_Table AdminDetails_Table { get; set; }
    }
}
