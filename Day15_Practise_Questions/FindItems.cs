namespace MyConsoleApp.Day15_Practise_Questons
{
    class Q1
    {
        // Predefined sorted dictionary
        public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>();

        // 1️⃣ Find item by sold count
        public static SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string, long> result = new SortedDictionary<string, long>();

            foreach (var item in itemDetails)
            {
                if (item.Value == soldCount)
                {
                    result.Add(item.Key, item.Value);
                    return result;
                }
            }

            return result; // Empty if not found
        }

    // 2️⃣ Find minimum and maximum sold items
        public static List<string> FindMinandMaxSoldItems()
        {
            List<string> list = new List<string>();

            long min = long.MaxValue;
            long max = long.MinValue;

            string minItem = "";
            string maxItem = "";

            foreach (var item in itemDetails)
            {
                if (item.Value < min)
                {
                    min = item.Value;
                    minItem = item.Key;
                }

                if (item.Value > max)
                {
                    max = item.Value;
                    maxItem = item.Key;
                }
            }

            list.Add(minItem);
            list.Add(maxItem);

            return list;
        }

        // 3️⃣ Sort by sold count
        public static Dictionary<string, long> SortByCount()
        {
            return itemDetails
                    .OrderBy(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
        }

        static void Main()
        {
            Console.Write("Enter number of items: ");
            int n = int.Parse(Console.ReadLine());

            // Get user input
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter item name: ");
                string name = Console.ReadLine();

                Console.Write("Enter sold count: ");
                long count = long.Parse(Console.ReadLine());

                itemDetails.Add(name, count);
            }

            Console.Write("\nEnter sold count to search: ");
            long searchCount = long.Parse(Console.ReadLine());

            var foundItems = FindItemDetails(searchCount);

            if (foundItems.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                Console.WriteLine("\nItem Found:");
                foreach (var item in foundItems)
                    Console.WriteLine(item.Key + " : " + item.Value);
            }

            Console.WriteLine("\nMinimum and Maximum Sold Items:");
            var minMaxList = FindMinandMaxSoldItems();
            Console.WriteLine("Minimum Sold Item: " + minMaxList[0]);
            Console.WriteLine("Maximum Sold Item: " + minMaxList[1]);

            Console.WriteLine("\nItems Sorted By Sold Count:");
            var sortedItems = SortByCount();
            foreach (var item in sortedItems)
                Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}