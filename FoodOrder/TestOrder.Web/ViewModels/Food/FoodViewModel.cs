using FoodOrder.Entities.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestOrder.Web.ViewModels.Restaurant;

namespace TestOrder.Web.ViewModels
{
    public class FoodViewModel
    {

        [Required(ErrorMessage = "Molim unesite ime naziv jela.")]
        [Display(Name = "Naziv jela")]
        public string NameOfTheFood { get; set; }

        [Required(ErrorMessage = "Molim unesite ime opis jela.")]
        [Display(Name = "Opis jela")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Molim unesite cijenu.")]
        [Display(Name = "Cijena jela")]
        public int Price { get; set; }

        public Nullable<int> RestaurantID { get; set; }
        public Nullable<double> AverageScore { get; set; }
        public string RestaurantName { get; set; }
        public int ID { get; set; }

        public FoodViewModel()
        {

        }


        public FoodViewModel(FoodDTO foodDto)
        {
            this.NameOfTheFood = foodDto.NameOfTheFood;
            this.Description = foodDto.Description;
            this.Price = foodDto.Price;
            this.RestaurantID = foodDto.RestaurantID;
            this.RestaurantName = foodDto.Restaurant.RestaurantName;
            this.AverageScore = foodDto.AverageScore;
            this.ID = foodDto.ID;
        }


    }
}