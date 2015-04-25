﻿using System;
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

namespace FoodOrder.Controllers
{
    public class RestaurantsController : Controller
    {
        private UnitOfWork unitOfWork;
        private MappingDTO mappingDto;
        private GenericRepository<Restaurant> mockRestaurants;
        public RestaurantsController()
        {
            unitOfWork = new UnitOfWork();
            mappingDto = new MappingDTO();
            
        }

        public RestaurantsController(GenericRepository<Restaurant> mockRestaurants)
        {
            this.mockRestaurants = mockRestaurants;
        }

        // GET: Restaurants
        public ActionResult Index( )
        {
            var restaurants = unitOfWork.RestaurantRepository.Get();
            return View(restaurants.ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var restaurant = unitOfWork.RestaurantRepository.GetByID(id);

            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);

        }

        // GET: Restaurants/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var restaurant = mappingDto.getRestaurantById(unitOfWork.RestaurantRepository.GetByID(id));
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RestaurantName,Address,PhoneNumber,DeliveryPrice")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
             //   db.Entry(restaurant).State = EntityState.Modified;


                unitOfWork.RestaurantRepository.Update(restaurant);
                unitOfWork.Save();
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
                public ActionResult Create([Bind(Include = "ID,RestaurantName,Address,PhoneNumber,DeliveryPrice")] Restaurant restaurant)
                {
                    if (ModelState.IsValid)
                    {
                        unitOfWork.RestaurantRepository.Insert(restaurant);
                        unitOfWork.Save();
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
