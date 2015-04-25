using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Web.Mvc;
using TestOrder.Web.Controllers;
using FoodOrder.Repository;
using Moq;
using FoodOrder.Controllers;
using TestOrder.Web.Models;
using System.Collections.Generic;
using FoodOrder.Entities;


namespace FoodOrder.Tests
{
   [TestClass]
    public class HomeControllerUnitTests
    {
       private UnitOfWork unitOfWork;
       private RestaurantsController restaurantController;

       public HomeControllerUnitTests()
       {
           unitOfWork = new UnitOfWork();
           restaurantController = new RestaurantsController();
       }


        [Test]
        public void IndexReturnsActionResult()
        {

            Mock<GenericRepository<FoodOrder.Entities.Restaurant>> mock = new Mock<GenericRepository<FoodOrder.Entities.Restaurant>>();

            mock.Setup(x => x.Insert(new FoodOrder.Entities.Restaurant
            {
                ID = 1,
                DeliveryPrice = 2,
                Address = "adresa",
                RestaurantName = "ImeRestorana",
                PhoneNumber = 555555,
                Person = new List<Person> { new Person { First_name = "Ivo", Last_name = "Ivic", ID = 2, UserID = "asdf" } },
                Food = new List<FoodOrder.Entities.Food>() 
                {new FoodOrder.Entities.Food { NameOfTheFood="Pizza", Description="description", ID=3, RestaurantID=2 }}
            }));


            var result = restaurantController.Index();



            NUnit.Framework.Assert.IsInstanceOf<List<FoodOrder.Entities.Restaurant>>(result);
           

        }
    }
}
