using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;
using OdeToFood.Data;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            this._context = context;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();

            return newRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            _context.Attach(restaurant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }
    }
}
