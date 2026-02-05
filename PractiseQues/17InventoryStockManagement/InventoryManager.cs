namespace _17InventoryStockManagement
{
    public class InventoryManager
    {
        private List<Product> products;
        private List<StockMovement> stockMovements;
        private int movementIdCounter;

        public InventoryManager()
        {
            products = new List<Product>();
            stockMovements = new List<StockMovement>();
            movementIdCounter = 1;
        }

        public void AddProduct(string code, string name, string category, string supplier, double price, int stock, int minLevel)
        {
            if (products.Any(p => p.ProductCode == code))
            {
                Console.WriteLine($"Product with code {code} already exists!");
                return;
            }

            products.Add(new Product
            {
                ProductCode = code,
                ProductName = name,
                Category = category,
                Supplier = supplier,
                UnitPrice = price,
                CurrentStock = stock,
                MinimumStockLevel = minLevel
            });
            Console.WriteLine($"Product '{name}' added successfully!");
        }

        public bool UpdateStock(string productCode, string movementType, int quantity, string reason)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == productCode);
            if (product == null)
            {
                Console.WriteLine($"Product with code {productCode} not found!");
                return false;
            }

            if (movementType.ToLower() == "in")
            {
                product.CurrentStock += quantity;
            }
            else if (movementType.ToLower() == "out")
            {
                if (product.CurrentStock < quantity)
                {
                    Console.WriteLine($"Insufficient stock! Available: {product.CurrentStock}, Requested: {quantity}");
                    return false;
                }
                product.CurrentStock -= quantity;
            }
            else
            {
                Console.WriteLine("Invalid movement type! Use 'In' or 'Out'");
                return false;
            }

            stockMovements.Add(new StockMovement
            {
                MovementId = movementIdCounter++,
                ProductCode = productCode,
                MovementDate = DateTime.Now,
                MovementType = movementType,
                Quantity = quantity,
                Reason = reason
            });

            Console.WriteLine($"Stock updated for {productCode}: {movementType} {quantity} ({reason})");
            return true;
        }

        public Dictionary<string, List<Product>> GroupProductsByCategory()
        {
            return products.GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Product> GetLowStockProducts()
        {
            return products.Where(p => p.CurrentStock <= p.MinimumStockLevel).ToList();
        }

        public Dictionary<string, int> GetStockValueByCategory()
        {
            return products.GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => (int)(g.Sum(p => p.CurrentStock * p.UnitPrice)));
        }
    }
}
