using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlexibleInventorySystem_Practice.Services;
using FlexibleInventorySystem_Practice.Models;

namespace FlexibleInventorySystem_Practice.UnitTest
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void AddProduct_ValidProduct_ReturnsTrue()
        {
            // Arrange
            var manager = new InventoryManager();
            var product = new ElectronicProduct
            {
                Id = "E100",
                Name = "Phone",
                Price = 500m,
                Quantity = 5,
                Category = "Electronics",
                DateAdded = DateTime.Now
            };

            // Act
            bool result = manager.AddProduct(product);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddProduct_NullProduct_ThrowsException()
        {
            // Arrange
            var manager = new InventoryManager();

            // Act
            manager.AddProduct(null);
        }

        [TestMethod]
        public void RemoveProduct_ExistingProduct_ReturnsTrue()
        {
            // Arrange
            var manager = new InventoryManager();
            var product = new ElectronicProduct
            {
                Id = "E101",
                Name = "Tablet",
                Price = 300m,
                Quantity = 3,
                Category = "Electronics",
                DateAdded = DateTime.Now
            };

            manager.AddProduct(product);

            // Act
            bool result = manager.RemoveProduct("E101");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FindProduct_ExistingProduct_ReturnsProduct()
        {
            // Arrange
            var manager = new InventoryManager();
            var product = new ElectronicProduct
            {
                Id = "E102",
                Name = "Monitor",
                Price = 200m,
                Quantity = 2,
                Category = "Electronics",
                DateAdded = DateTime.Now
            };

            manager.AddProduct(product);

            // Act
            var found = manager.FindProduct("E102");

            // Assert
            Assert.IsNotNull(found);
            Assert.AreEqual("Monitor", found.Name);
        }

        [TestMethod]
        public void GetTotalInventoryValue_ReturnsCorrectSum()
        {
            // Arrange
            var manager = new InventoryManager();

            manager.AddProduct(new ElectronicProduct
            {
                Id = "E200",
                Name = "Keyboard",
                Price = 100m,
                Quantity = 2,
                Category = "Electronics",
                DateAdded = DateTime.Now
            });

            manager.AddProduct(new ElectronicProduct
            {
                Id = "E201",
                Name = "Mouse",
                Price = 50m,
                Quantity = 4,
                Category = "Electronics",
                DateAdded = DateTime.Now
            });

            // Act
            decimal total = manager.GetTotalInventoryValue();

            // Assert
            Assert.AreEqual(100m * 2 + 50m * 4, total);
        }
    }
}
