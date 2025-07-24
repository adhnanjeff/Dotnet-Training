using System;
namespace Day3Proj2_BookRentalSystem.Services;
using System.Collections.Generic;
using Day3Proj2_BookRentalSystem.Models;

public class BookService : IBookService {

    public void ReportStatus(List<IRentable> rented)
    {
        foreach (var rent in rented)
        {
            rent.BookReport();
        }
    }
    public void DisplayAllBooks(List<Book> books) {
        if (books == null || books.Count == 0) {
            Console.WriteLine("No books available to display.");
            return;
        }
        foreach (var book in books) {
            book.Display();
            Console.WriteLine();
        }
    }
}