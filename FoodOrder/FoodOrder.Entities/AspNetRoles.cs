//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodOrder.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            this.AspNetUsers = new HashSet<AspNetUsers>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
