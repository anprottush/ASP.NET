//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Food
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string AssignedEmployee { get; set; }
        public string RequestedRestaurant { get; set; }
    }
}
