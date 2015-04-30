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
    public class MappingRestaurantDTO
    {
        private RestaurantDTO restaurantDTO;
        private List<RestaurantDTO> restaurantsDTO;
        private Restaurant restaurant;

        public MappingRestaurantDTO()
        {
            restaurantDTO = new RestaurantDTO();
            restaurantsDTO = new List<RestaurantDTO>();
            restaurant = new Restaurant();
        }

        public RestaurantDTO getRestaurantById(Restaurant restaurant)
        {
            Mapper.CreateMap<Restaurant, RestaurantDTO>();
            restaurantDTO = Mapper.Map<RestaurantDTO>(restaurant);

            return restaurantDTO;
        }

        public List<RestaurantDTO> getRestaurants(List<Restaurant> restaurants)
        {
            foreach (var restaurant in restaurants)
            {
                Mapper.CreateMap<Restaurant, RestaurantDTO>();
                restaurantsDTO.Add(Mapper.Map<RestaurantDTO>(restaurant));                
            }
            
            return restaurantsDTO;
        }

        public Restaurant setRestaurants(RestaurantDTO restaurantDto)
        {
            Mapper.CreateMap<RestaurantDTO, Restaurant>();
            restaurant = Mapper.Map<Restaurant>(restaurantDto);
            return restaurant;
        }


    }
}
