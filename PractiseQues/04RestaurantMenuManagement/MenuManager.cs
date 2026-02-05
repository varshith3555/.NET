namespace RestaurantMenuManagement;

class MenuManager
{
    private Dictionary<int, MenuItem> menu = new Dictionary<int, MenuItem>();

    public void AddMenuItem(string name, string category, double price, bool isVeg)
    {
        int key = menu.Count + 1;
        menu.Add(key, new MenuItem
        {
            ItemName = name, Category = category, Price = price, IsVegetarian = isVeg
        });
    }
    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        return new Dictionary<string, List<MenuItem>>(
            menu.Values.GroupBy(e => e.Category).ToDictionary(g => g.Key, g => g.ToList())
        );
    }
    public List<MenuItem> GetVegetarianItems()
    {
        return menu.Values.Where(e => e.IsVegetarian).ToList();
    }
    public double CalculateAveragePriceByCategory(string category)
    {
        return menu.Values.Where(e =>e.Category == category).Average(e => e.Price);
    }
}