using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Entities.DTO
{
    public class ScoreDTO
    {
        public int ID { get; set; }
        public int ReviewScore { get; set; }
        public Nullable<int> PersonID { get; set; }
        public Nullable<int> FoodID { get; set; }

        public virtual Food Food { get; set; }
        public virtual Person Person { get; set; }
    }
}
