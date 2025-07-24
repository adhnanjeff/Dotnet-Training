using System;
namespace Day3Proj2_BookRentalSystem.Models
{
    public abstract class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }
        public Book(int id, string title, string author) {
            Id = id;
            Title = title;
            Author = author;
            IsAvailable = true;
        }

        public abstract void Display();
    }
}