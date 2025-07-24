using System;
using System.Collections.Generic;
using Day3Proj2_BookRentalSystem.Models;
using Day3Proj2_BookRentalSystem.Services;

namespace Day3Proj2_BookRentalSystem {
    class Program {
        static void Main(string[] args) {
            Fiction fictionBook = new Fiction(1, "The White Knight", "Dovstky", "Romance");
            NonFiction nonFictionBook = new NonFiction(2, "Olivers Twist", "Charles Dickens", "History");
            Fiction fictionBook2 = new Fiction(3, "The Great Gatsby", "F. Scott Fitzgerald", "Classic");
            NonFiction nonFictionBook2 = new NonFiction(4, "Sapiens", "Yuval Noah Harari", "Anthropology");

            List<Book> books = new List<Book>() { fictionBook, nonFictionBook, fictionBook2, nonFictionBook2 };
            List<IRentable> rentables = new List<IRentable>() { fictionBook, nonFictionBook, fictionBook2, nonFictionBook2 };

            BookService bookService = new BookService();
            bookService.DisplayAllBooks(books);

            fictionBook.Rent();
            nonFictionBook.Rent();
            fictionBook2.Rent();
            nonFictionBook2.Rent();

            Console.WriteLine("\nRented Books Report:");
            bookService.ReportStatus(rentables);

            Console.WriteLine("\nReturning Books:");
            fictionBook.Return();
            nonFictionBook.Return();

            Console.WriteLine("\nUpdated Books Report:");
            bookService.ReportStatus(rentables);
        }
    }
}