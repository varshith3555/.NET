public class InventoryManager
{
    private SortedDictionary<string, Product> product = new SortedDictionary<string, Product>();
    public void AddProduct(string name, string category, double price, int stock)
    {
        
    }
    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        
    }
    public bool UpdateStock(string productCode, int quantity)
    {
        
    }
    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        
    }
    public Dictionary<string, int> GetCategoryStockSummary()
    {
        
    }
}