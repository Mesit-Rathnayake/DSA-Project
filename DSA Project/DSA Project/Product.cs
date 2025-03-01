using System;

namespace DSA_Project
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void DisplayProducts()
        {
            Console.WriteLine($"\n Product: {Name}");
            Console.WriteLine($" Price: {Price:C}");
            Console.WriteLine($" Stock: {Stock}\n");
        }

        // Override ToString() for better object printing
        public override string ToString()
        {
            return $"{Name} -  {Price:C} -  {Stock} in stock";
        }
    }
}
