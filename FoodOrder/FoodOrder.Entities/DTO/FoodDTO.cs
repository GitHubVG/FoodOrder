using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Entities.DTO
{
    public class FoodDTO
    {
        public int ID { get; set; }
        public string NameOfTheFood { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Nullable<double> AverageScore { get; set; }
        public Nullable<int> RestaurantID { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual Person Person { get; set; }
    }
}
