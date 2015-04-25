using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodOrder.Entities;
using FoodOrder.Repository.Data;
using FoodOrder.Repository;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using FoodOrder.Core;

namespace TestOrder.Web.Controllers
{
    public class FoodController : Controller
    {
        
        private UnitOfWork unitOfWork;
        private VotingCheck checkVoting;
        public FoodController()
        {
            unitOfWork = new UnitOfWork();
            checkVoting = new VotingCheck();
        }

        // GET: Food
        public ActionResult Index(int? FoodByRestaurant=1)
        {



            var food = unitOfWork.FoodRepository.Get().Where(x => x.RestaurantID == FoodByRestaurant);
            return View(food.ToList());
        }

        // GET: Food/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var food = unitOfWork.FoodRepository.GetByID(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Food/Create
        [Authorize]
        public ActionResult Create()
        {


            ViewBag.RestaurantID = new SelectList(unitOfWork.RestaurantRepository.Get(), "ID", "RestaurantName");
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Price,ReviewScore,RestaurantID,NameOfTheFood")] Food food)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FoodRepository.Insert(food);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantID = new SelectList(unitOfWork.RestaurantRepository.Get(), "ID", "RestaurantName", food.RestaurantID);
            return View(food);
        }

        // GET: Food/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var food = unitOfWork.FoodRepository.GetByID(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantID = new SelectList(unitOfWork.RestaurantRepository.Get(), "ID", "RestaurantName", food.RestaurantID);
            return View(food);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Price,ReviewScore,RestaurantID,NameOfTheFood")] Food food, string NameOfTheFood)
        {
            if (ModelState.IsValid)
            {
                food.NameOfTheFood = NameOfTheFood;
                unitOfWork.FoodRepository.Update(food);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantID = new SelectList(unitOfWork.RestaurantRepository.Get(), "ID", "RestaurantName", food.RestaurantID);
            return View(food);
        }



        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var food = unitOfWork.FoodRepository.GetByID(id);
            unitOfWork.FoodRepository.Delete(food);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult GetFoodByRestaurant(int id)
        {
            return View(unitOfWork.FoodRepository.Get().Where(x => x.RestaurantID == id));

        }


        [Authorize]
        public ActionResult SetScore(int? id)
        {
       
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.FoodID = unitOfWork.FoodRepository.GetByID(id).ID;

            if (unitOfWork.FoodRepository.GetByID(id) == null)
            {
                return HttpNotFound();
            }

            var idOfLoggedUserFromLocalDb = User.Identity.GetUserId(); //ID trenutnog korisnika
    
            if (checkVoting.CheckIfUserAlreadyVoted(idOfLoggedUserFromLocalDb,id))
            {
                ViewBag.DidUSerAlreadyVote = true;
                ViewBag.Score = checkVoting.CheckReviewScore();
                return View();
            }
            else
            {
                ViewBag.DidUSerAlreadyVote = false;
            
                return View();
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult SetScore(Score score, int id,int VotingScore)
        {
            var idOfLoggedUserFromLocalDb = User.Identity.GetUserId(); //ID trenutnog korisnika

            var curretUser = unitOfWork.PersonRepository.Get().Single(userID => userID.UserID == idOfLoggedUserFromLocalDb);

            score.FoodID = id;
            score.PersonID = curretUser.ID;
            score.ReviewScore = VotingScore;
            if (ModelState.IsValid)
            {
                unitOfWork.ScoreRepository.Insert(score);
                unitOfWork.Save();
                unitOfWork.FoodRepository.GetByID(id).AverageScore = unitOfWork.ScoreRepository.Get().Where(x => x.FoodID == id).Select(x => x.ReviewScore).Average();
                unitOfWork.Save();

                return RedirectToAction("Index", "Home");
            }

            return View(score);


        }
    }
}
