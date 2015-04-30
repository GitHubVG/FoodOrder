using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrder.Repository.Data;
using FoodOrder.Repository;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using FoodOrder.Core;
using FoodOrder.Process;
using AutoMapper;
using FoodOrder.Entities.DTO;
using FoodOrder.Entities;
namespace TestOrder.Web.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;

        private RestaurantProcess restaurantProcess;
        private PersonProcess personProcess;
        private PieChart pieChart;
        private Votes votes;
        private Person person;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
            restaurantProcess = new RestaurantProcess();
            pieChart = new PieChart();
            votes = new Votes();
            personProcess = new PersonProcess();
            person = new Person();
        }

        public ActionResult Index()
        {

            votes.removeAllVotes();
            ViewBag.FoodByRestaurant = new SelectList(restaurantProcess.getAllRestaurants(), "ID", "RestaurantName");

            return View();
        }

        public JsonResult GetVotes()
        {

            var chartData = pieChart.InfoToDisplayInPieChart();
            return Json(chartData, JsonRequestBehavior.AllowGet);
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
            ViewBag.FoodByRestaurant = new SelectList(restaurantProcess.getAllRestaurants(), "ID", "RestaurantName");
            ViewBag.Time = DateTime.Now.Hour;

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult VoteForCatering(int FoodByRestaurant)
        {
            ViewBag.FoodByRestaurant = new SelectList(restaurantProcess.getAllRestaurants(), "ID", "RestaurantName");
            var idOfLoggedUserFromLocalDb = User.Identity.GetUserId();
            var personToUpdate = unitOfWork.PersonRepository.Get().Single(x => x.UserID == idOfLoggedUserFromLocalDb);

            personToUpdate.RestaurantVote = FoodByRestaurant;
            unitOfWork.PersonRepository.Update(personToUpdate);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}