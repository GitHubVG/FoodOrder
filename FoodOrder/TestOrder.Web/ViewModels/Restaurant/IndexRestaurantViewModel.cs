using FoodOrder.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOrder.Web.ViewModels.Restaurant
{
    public class IndexRestaurantViewModel : RestaurantViewModel
    {
        public List<RestaurantViewModel> listOfRestaurantViewModels { get; set; }

        public IndexRestaurantViewModel(List<RestaurantDTO> restaurantDtos)
        {
            listOfRestaurantViewModels = new List<RestaurantViewModel>();
            foreach (var restaurantDto in restaurantDtos)
            {
                listOfRestaurantViewModels.Add(new RestaurantViewModel(restaurantDto));

            }



        }
    }
}