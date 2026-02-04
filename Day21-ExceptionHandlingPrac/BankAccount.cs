public class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        try{
            Console.WriteLine("Enter withdrawal amount:");
            int amount = int.Parse(Console.ReadLine()!);

            if(amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero");
            }
            if(amount > balance)
            {
                throw new InvalidOperationException("Insufficient balance");
            }
            if(amount < balance)
            {
                balance -= amount;
                Console.WriteLine("Remaining Balance: " + balance);
            }
        }catch(ArgumentException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch(InvalidOperationException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally{
            System.Console.WriteLine("Transaction completed");
        }
    }
}