using FoodOrder.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOrder.Web.ViewModels.Food
{
    public class IndexFoodViewModel 
    {
        public List<GetFoodByRestaurantViewModel> listOfFoodByRestaurant { get; set; }

        public IndexFoodViewModel(List<FoodDTO> foodDtos)
            
        {
            listOfFoodByRestaurant = new List<GetFoodByRestaurantViewModel>();
            foreach (var foodDto in foodDtos)
            {
                listOfFoodByRestaurant.Add(new GetFoodByRestaurantViewModel(foodDto));

            }



        }

    }
}