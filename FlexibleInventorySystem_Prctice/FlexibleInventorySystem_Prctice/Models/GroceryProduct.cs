using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
        /// <summary>
        /// TODO: Implement grocery product class
        /// </summary>
        public class GroceryProduct : Product
        {
            // TODO: Add these properties
            // - ExpiryDate (DateTime)
            // - IsPerishable (bool)
            // - Weight (double)
            // - StorageTemperature (string) - e.g., "Room temperature", "Refrigerated", "Frozen"
            public DateTime ExpiryDate { get; set; }
            public bool IsPerishable { get; set; }
            public double Weight { get; set; }
            public string? StorageTemperature { get; set; }

            /// <summary>
            /// TODO: Override GetProductDetails for grocery items
            /// Include expiry information
            /// </summary>
            public override string GetProductDetails()
            {
                // TODO: Implement
                return $"ID: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}, Expiry Date: {ExpiryDate}, Perishable: {IsPerishable}, Weight: {Weight}kg, Storage: {StorageTemperature}";
            }

            /// <summary>
            /// TODO: Check if product is expired
            /// </summary>
            public bool IsExpired()
            {
                // TODO: Compare ExpiryDate with current date
                DateTime curr = DateTime.Now.Date;
                return curr > ExpiryDate.Date;
            }

            /// <summary>
            /// TODO: Calculate days until expiry
            /// Return negative if expired
            /// </summary>
            public int DaysUntilExpiry()
            {
                // TODO: Calculate days difference
                return (ExpiryDate.Date - DateTime.Now.Date).Days;
            }

            /// <summary>
            /// TODO: Override CalculateValue to apply discount for near-expiry items
            /// Apply 20% discount if within 3 days of expiry
            /// </summary>
            public override decimal CalculateValue()
            {
                // TODO: Apply discount logic if near expiry
                decimal baseValue = Price * Quantity;
                int daysL = DaysUntilExpiry();
                if(daysL >= 0 && daysL <= 3)
                {
                    return baseValue * 0.8m;
                }
                return baseValue;
            }
        }
    }

