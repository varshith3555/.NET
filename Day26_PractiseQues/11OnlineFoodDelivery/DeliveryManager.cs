using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineFoodDelivery
{
    public class DeliveryManager
    {
        private List<Restaurant> restaurants = new List<Restaurant>();
        private List<FoodItem> foodItems = new List<FoodItem>();
        private List<Order> orders = new List<Order>();
        private int restaurantId = 6001;
        private int itemId = 7001;
        private int orderId = 8001;

        public void AddRestaurant(string name, string cuisine, string location, double charge)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Restaurant name cannot be empty.");

            restaurants.Add(new Restaurant
            {
                RestaurantId = restaurantId++,
                Name = name,
                CuisineType = cuisine,
                Location = location,
                DeliveryCharge = charge
            });
        }

        public void AddFoodItem(int restaurantId, string name, string category, double price)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.RestaurantId == restaurantId);
            if (restaurant == null)
                throw new Exception("Restaurant not found.");

            foodItems.Add(new FoodItem
            {
                ItemId = itemId++,
                Name = name,
                Category = category,
                Price = price,
                RestaurantId = restaurantId
            });
        }

        public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
        {
            var grouped = new Dictionary<string, List<Restaurant>>();
            foreach (var restaurant in restaurants)
            {
                if (!grouped.ContainsKey(restaurant.CuisineType))
                    grouped[restaurant.CuisineType] = new List<Restaurant>();
                grouped[restaurant.CuisineType].Add(restaurant);
            }
            return grouped;
        }

        public bool PlaceOrder(int customerId, List<int> itemIds)
        {
            var items = new List<FoodItem>();
            double total = 0;

            foreach (var id in itemIds)
            {
                var item = foodItems.FirstOrDefault(f => f.ItemId == id);
                if (item == null)
                    throw new Exception($"Food item {id} not found.");
                items.Add(item);
                total += item.Price;
            }

            orders.Add(new Order
            {
                OrderId = orderId++,
                CustomerId = customerId,
                Items = items,
                OrderTime = DateTime.Now,
                Status = "Pending",
                TotalAmount = total
            });

            return true;
        }

        public List<Order> GetPendingOrders()
        {
            return orders.Where(o => o.Status == "Pending").ToList();
        }
    }
}
