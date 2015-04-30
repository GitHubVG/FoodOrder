using AutoMapper;
using FoodOrder.Entities.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestOrder.Web.ViewModels.Restaurant
{
    public class RestaurantViewModel
    {

        public int ID { get; set; }


        [Required(ErrorMessage = "Molim unesite ime restorana.")]
        [Display(Name = "Restoran")]
        public string RestaurantName { get; set; }
                
        [Required(ErrorMessage = "Molim unesite adresu restorana.")]
        [Display(Name = "Adresa restorana")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Molim unesite broj telefona.")]
        [Display(Name = "Telefon")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Molim unesite cijenu dostave.")]
        [Display(Name = "Cijena dostave")]
        public int DeliveryPrice { get; set; }


        public RestaurantViewModel()
        {

        }

        public RestaurantViewModel(RestaurantDTO restaurantDto)
        {
            this.ID = restaurantDto.ID;
            this.RestaurantName = restaurantDto.RestaurantName;

            this.Address = restaurantDto.Address;
            this.PhoneNumber = restaurantDto.PhoneNumber;
            this.DeliveryPrice = restaurantDto.DeliveryPrice;
       
        }

 
    }
}