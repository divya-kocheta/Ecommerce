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
    
    public partial class Cart_item
    {
        public int Cart_ID { get; set; }
        public string Product_image { get; set; }
        public string Product_name { get; set; }
        public int Product_quantity { get; set; }
        public int Product_price { get; set; }
        public int Cart_total_price { get; set; }
        public int FK_productID { get; set; }
    
        public virtual Product_table Product_table { get; set; }
    }
}
