using FoodOrder.Core;
using FoodOrder.Entities.DTO;
using FoodOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodOrder.Process
{
    public class RestaurantProcess
    {
        public UnitOfWork unitOfWork;
        private RestaurantDTO restaurantDTO;
        private MappingRestaurantDTO mapRestaurants;

        public RestaurantProcess()
        {
            unitOfWork = new UnitOfWork();
            restaurantDTO = new RestaurantDTO();
            mapRestaurants = new MappingRestaurantDTO();
        }

        
        public List<RestaurantDTO> getAllRestaurants()
        {

            return mapRestaurants.getRestaurants(unitOfWork.RestaurantRepository.Get().ToList());

        }

        public RestaurantDTO getRestaurantById(int id)
        {
            return mapRestaurants.getRestaurantById(unitOfWork.RestaurantRepository.GetByID(id));
        }

        public void insertRestaurant(RestaurantDTO restaurantDto)
        {
          

            unitOfWork.RestauranDTOtRepository.Insert(restaurantDto);
            unitOfWork.Save();
        }

    }
}
