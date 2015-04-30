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
using FoodOrder.Core;
using FoodOrder.Process;
using TestOrder.Web.ViewModels.Restaurant;
using FoodOrder.Entities.DTO;
using AutoMapper;

namespace FoodOrder.Controllers
{
    public class RestaurantsController : Controller
    {
        private UnitOfWork unitOfWork;
        private MappingRestaurantDTO mappingDto;
        private RestaurantProcess restaurantProcess;
        private RestaurantViewModel restaurantViewModel;
        private IndexRestaurantViewModel indexRestaurantViewModel;
        private MappingRestaurantDTO mappingRestaurantDto;

        private RestaurantDTO restaurantDTO;

        private GenericRepository<Restaurant> mockRestaurants;
        public RestaurantsController()
        {
            unitOfWork = new UnitOfWork();
            mappingDto = new MappingRestaurantDTO();
            restaurantProcess = new RestaurantProcess();
            restaurantDTO = new RestaurantDTO();
            mappingRestaurantDto = new MappingRestaurantDTO();
        }

        public RestaurantsController(GenericRepository<Restaurant> mockRestaurants)
        {
            this.mockRestaurants = mockRestaurants;
        }

        // GET: Restaurants
        public ActionResult Index()
        {

            var restaurants = indexRestaurantViewModel = new IndexRestaurantViewModel(restaurantProcess.getAllRestaurants());


            return View(restaurants);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            restaurantViewModel = new RestaurantViewModel(restaurantProcess.getRestaurantById(id));
            var restaurant = restaurantViewModel;
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);

        }

        // GET: Restaurants/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            restaurantViewModel = new RestaurantViewModel(restaurantProcess.getRestaurantById(id));

            if (restaurantViewModel == null)
            {
                return HttpNotFound();
            }
            return View(restaurantViewModel);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RestaurantName,Address,PhoneNumber,DeliveryPrice")] RestaurantViewModel restaurant)
        {
            if (ModelState.IsValid)
            {
                //  db.Entry(restaurant).State = EntityState.Modified;

                Mapper.CreateMap<RestaurantViewModel, RestaurantDTO>();
                restaurantDTO = Mapper.Map<RestaurantDTO>(restaurant);
                restaurantProcess.unitOfWork.RestaurantRepository.Update(mappingRestaurantDto.setRestaurants(restaurantDTO));


                restaurantProcess.unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }





        // GET: Restaurants/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RestaurantName,Address,PhoneNumber,DeliveryPrice")] RestaurantViewModel restaurant)
        {
            if (ModelState.IsValid)
            {

                Mapper.CreateMap<RestaurantViewModel, RestaurantDTO>();
                restaurantDTO = Mapper.Map<RestaurantDTO>(restaurant);
                restaurantProcess.unitOfWork.RestaurantRepository.Insert(mappingRestaurantDto.setRestaurants(restaurantDTO));

                //unitOfWork.RestaurantRepository.Insert(restaurant);
             

                restaurantProcess.unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }


        // GET: Restaurants/Delete/5


        // POST: Restaurants/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var restaurant = unitOfWork.RestaurantRepository.GetByID(id);
            //restaurantViewModel = new RestaurantViewModel(restaurantProcess.getRestaurantById(id));

           unitOfWork.RestaurantRepository.Delete(restaurant);
           unitOfWork.Save();
           return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}
