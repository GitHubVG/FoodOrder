using AutoMapper;
using FoodOrder.Entities;
using FoodOrder.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Core
{
    public class MappingDTO
    {
        private RestaurantDTO restaurantDTO;


        public MappingDTO()
        {
            restaurantDTO = new RestaurantDTO();
        }

        public RestaurantDTO getRestaurantById(Restaurant restaurant)
        {
            Mapper.CreateMap<Restaurant, RestaurantDTO>();
            restaurantDTO = Mapper.Map<RestaurantDTO>(restaurant);

            return restaurantDTO;
        }

    }
}
