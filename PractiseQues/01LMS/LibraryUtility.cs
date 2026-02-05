using System;
using System.Collections.Generic;
using System.Linq;

class LibraryUtility
{
    private SortedDictionary<int, Book> books = new SortedDictionary<int, Book>();
    public void AddBook(string title, string author, string genre, int publicationYear)
    {
        int Key = books.Count + 1;
        books.Add(Key,new Book()
        {
            Title = title, Author = author, Genre = genre, PublicationYear = publicationYear
        });
    }

    public SortedDictionary<string, List<Book>> GroupBooksByGenre()
    {
        var groupedBooks = books.Values
            .GroupBy(e => e.Genre)
            .ToDictionary(g => g.Key, g => g.ToList());
        return new SortedDictionary<string, List<Book>>(groupedBooks);
    }
    public List<Book> GetBookByAuthor(string author)
    {
        return new List<Book>(
            books.Values.Where(a => a.Author == author).ToList()
        );
    }
    public int GetTotalBookCount(){
        return books.Count;
    }
}