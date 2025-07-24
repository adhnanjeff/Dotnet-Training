using System;
using Day3Proj2_BookRentalSystem.Models;
using Day3Proj2_BookRentalSystem.Services;

public interface IBookService
{
    void ReportStatus(List<IRentable> rented);
    void DisplayAllBooks(List<Book> books);
}