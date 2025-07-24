using System;
namespace Day3Proj2_BookRentalSystem.Models
{
    public interface IRentable {
        void Rent();
        void Return();
        void BookReport();
    }
}