using FoodOrder.Entities.DTO;
using FoodOrder.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Process
{
    public class FoodProcess
    {
        public UnitOfWork unitOfWork;
        private FoodDTO foodDTO;
        private MappingFoodDTO mappingFoodDto;
        private List<FoodDTO> listOfFoodDto;
        private List<FoodDTO> allFood;
        public FoodProcess()
        {
            unitOfWork = new UnitOfWork();
            foodDTO = new FoodDTO();
            mappingFoodDto = new MappingFoodDTO();
            allFood = new List<FoodDTO>();
        }

        public FoodDTO getFoodById(int id)
        {
            return mappingFoodDto.getFoodById(unitOfWork.FoodRepository.GetByID(id));
        }
        
        public List<FoodDTO> getAllFood()
        {
            allFood = mappingFoodDto.getFood(unitOfWork.FoodRepository.Get().ToList());
            return allFood;
        }


        public List<FoodDTO> getFoodByRestaurant(List<FoodDTO> foodsDtos, int id)
        {

            var restaurantsById = foodsDtos.Where(x => x.RestaurantID == id);

            return restaurantsById.ToList();
        }


    }
}
