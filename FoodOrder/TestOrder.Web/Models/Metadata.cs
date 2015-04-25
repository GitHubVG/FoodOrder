
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TestOrder.Web.Models
{


    //Restaurant

    [MetadataType(typeof(MetadataRestaurant))]
    public partial class Restaurant : FoodOrder.Entities.Restaurant
    {
        
    }

    public class MetadataRestaurant
    {

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


    }

    //Food
    [MetadataType(typeof(MetadataFood))]
    public partial class Food
    {

    }
    public class MetadataFood
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

    }

    //Person

    [MetadataType(typeof(MetadataScore))]
    public partial class Score
    {

    }
    public class MetadataScore
    {
        [Display(Name = "Ocjena jela od 1 do 5")]
        [Range(1, 5)]
        public int ReviewScore { get; set; }
    }
}
