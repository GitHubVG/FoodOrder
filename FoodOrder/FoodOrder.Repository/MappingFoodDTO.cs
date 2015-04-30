using AutoMapper;
using FoodOrder.Entities;
using FoodOrder.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Repository
{
    public class MappingFoodDTO
    {
        private FoodDTO foodDTO;
        private List<FoodDTO> foodsDTO;
        private Food food;

        public MappingFoodDTO()
        {
            foodDTO = new FoodDTO();
            foodsDTO = new List<FoodDTO>();
            food = new Food();
        }

        public FoodDTO getFoodById(Food food)
        {
            Mapper.CreateMap<Food, FoodDTO>();
            foodDTO = Mapper.Map<FoodDTO>(food);

            return foodDTO;
        }

        public List<FoodDTO> getFood(List<Food> foods)
        {
            foreach (var food in foods)
            {
                Mapper.CreateMap<Food, FoodDTO>();
                foodsDTO.Add(Mapper.Map<FoodDTO>(food));
            }

            return foodsDTO;
        }

        public Food setFood(FoodDTO foodDto)
        {
            Mapper.CreateMap<FoodDTO, Food>();
            food = Mapper.Map<Food>(foodDto);
            return food;
        }

    }
}
