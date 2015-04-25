using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Entities.DTO
{
    public class RestaurantDTO
    {

        public int ID { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int DeliveryPrice { get; set; }

        public virtual ICollection<Food> Food { get; set; }


    }
}
