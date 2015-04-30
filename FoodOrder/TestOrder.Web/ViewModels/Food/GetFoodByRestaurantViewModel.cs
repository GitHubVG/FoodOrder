using FoodOrder.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOrder.Web.ViewModels.Food
{
    public class GetFoodByRestaurantViewModel : FoodViewModel
    {
        public Nullable<int> RestaurantID { get; set; }

        public GetFoodByRestaurantViewModel(FoodDTO foodDto):base(foodDto)
        {
            this.RestaurantID = foodDto.RestaurantID;

        }



    }
}