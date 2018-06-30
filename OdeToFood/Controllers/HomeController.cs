using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private readonly IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,IGreeter greeter)
        {
            this._restaurantData = restaurantData;
            this._greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessage();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null) return RedirectToAction(nameof(Index));

            return View(model);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                Restaurant newRestaurant = new Restaurant
                {
                    Cuisine = model.Cuisine,
                    Name = model.Name
                };

                newRestaurant = _restaurantData.Add(newRestaurant);
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }
    }
}