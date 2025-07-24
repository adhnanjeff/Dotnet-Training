using System;
namespace Day3Proj2_BookRentalSystem.Models
{
    public class NonFiction : Book, IRentable
    {
        public string Category { get; set; }
        public NonFiction(int id, string title, string author, string cat) : base(id, title, author)
        {
            if (string.IsNullOrWhiteSpace(cat))
                throw new ArgumentException("Genre cannot be empty.", nameof(cat));
            Category = cat;
        }

        public void BookReport() {
            Console.WriteLine($"Book Report for '{Title}' by {Author}:");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Genre: {Category}");
            Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
        }
        public void Rent()
        {
            if (!IsAvailable)
            {
                Console.WriteLine("This book is currently not available for rent.");
                return;
            }
            IsAvailable = false;
            Console.WriteLine($"You have rented '{Title}' by {Author}.");
        }

        public void Return() { 
            if(!IsAvailable) {
                IsAvailable = true;
                Console.WriteLine($"You have returned '{Title}' by {Author}.");
            }
        }

        public override void Display()
        {
            Console.WriteLine("$Non-Fiction Book Deatils:");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Genre: {Category}");
            Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
        }
    }
}