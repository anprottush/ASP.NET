//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class FoodCollection
    {
        public int Id { get; set; }
        public string FoodType { get; set; }
        public string Quantity { get; set; }
        public string Status { get; set; }
        public Nullable<int> AssignedEmployee { get; set; }
        public int RequestedRestaurant { get; set; }
    
        public virtual NGOEmployee NGOEmployee { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
