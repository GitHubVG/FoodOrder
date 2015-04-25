using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Entities.DTO
{
    public class PersonDTO
    {
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
