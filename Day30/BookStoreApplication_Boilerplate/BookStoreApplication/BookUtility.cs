using System;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
            // TODO: Assign book object
            _book = book;
        }

        public void GetBookDetails()
        {
            // TODO:
            // Print format:
            // Details: <BookId> <Title> <Price> <Stock>
            System.Console.WriteLine(_book.Id + " "+ _book.Title+" "+ _book.Price + " "+_book.Stock);
        }

        public void UpdateBookPrice(int newPrice)
        {
            // TODO:
            // Validate new price
            // Update price
            // Print: Updated Price: <newPrice>
            if(newPrice > 0  && newPrice != _book.Price){
                _book.Price = newPrice;
                System.Console.WriteLine(newPrice);
            }
            else
            {
                System.Console.WriteLine("Invalid Price");
            }

        }

        public void UpdateBookStock(int newStock)
        {
            // TODO:
            // Validate new stock
            // Update stock
            // Print: Updated Stock: <newStock>
            if(newStock <=0 || newStock == _book.Stock)
            {
                System.Console.WriteLine("Invalid Stock");
                return;
            }
            _book.Stock = newStock;
            System.Console.WriteLine(_book.Stock);
        }
    }
}
