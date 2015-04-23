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
    
    public partial class Person
    {
        public Person()
        {
            this.Food = new HashSet<Food>();
            this.Order = new HashSet<Order>();
            this.Score = new HashSet<Score>();
        }
    
        public int ID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string UserID { get; set; }
        public Nullable<int> RestaurantVote { get; set; }
    
        public virtual ICollection<Food> Food { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Score> Score { get; set; }
    }
}