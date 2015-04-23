using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrder.Repository.Data;
using FoodOrder.Repository;
using System.Web.Security;
using Microsoft.AspNet.Identity;
namespace TestOrder.Web.Controllers
    
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;
       
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
            
        }

        public ActionResult Index()
        {
      
 
            ViewBag.FoodByRestaurant = new SelectList(unitOfWork.RestaurantRepository.Get(), "ID", "RestaurantName");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "O projektu.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt.";

            return View();
        }

        [Authorize]
        public ActionResult VoteForCatering()
        {
            ViewBag.FoodByRestaurant = new SelectList(unitOfWork.RestaurantRepository.Get(), "ID", "RestaurantName");
            ViewBag.Time = DateTime.Now.Hour;

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult VoteForCatering(int FoodByRestaurant)
        {
           ViewBag.FoodByRestaurant = new SelectList(unitOfWork.RestaurantRepository.Get(), "ID", "RestaurantName");
           var idOfLoggedUserFromLocalDb = User.Identity.GetUserId();
           var currentPerson = unitOfWork.PersonRepository.Get().Single(x => x.UserID == idOfLoggedUserFromLocalDb);
           currentPerson.RestaurantVote=FoodByRestaurant;
           unitOfWork.PersonRepository.Update(currentPerson);
           unitOfWork.Save();

           return View("Index");
        }
    }
}