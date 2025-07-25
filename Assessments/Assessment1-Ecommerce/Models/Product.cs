    using System;

    namespace Assessment1_Ecommerce.Models
    {
        public abstract class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }

            public Product(int id, string name, string description, decimal price, int stockQuantity)
            {
                Id = id;
                Name = name;
                Description = description;
                Price = price;
                StockQuantity = stockQuantity;
            }

            public abstract void DisplayProductInfo();
        }
    }