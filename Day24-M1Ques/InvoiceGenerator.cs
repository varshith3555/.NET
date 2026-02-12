using System.Text;

class InvoiceGenerator
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        decimal grandTotal = 0;
        for(int i = 0; i < 5; i++)
        {
            System.Console.WriteLine("Item Name");
            string itemName = Console.ReadLine()!;

            System.Console.WriteLine("Enter Qantity");
            int qty = int.Parse(Console.ReadLine()!);

            System.Console.WriteLine("Price");
            decimal price = decimal.Parse(Console.ReadLine()!);

            decimal lineTotal = qty * price;
            grandTotal += lineTotal;
            sb.AppendLine($"{itemName}\t{qty}\t{price}\t{lineTotal}");

        }
        Console.WriteLine("\n" + sb.ToString());
    }
}