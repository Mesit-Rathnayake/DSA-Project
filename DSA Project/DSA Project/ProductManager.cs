using System;
using System.IO;
using System.Collections.Generic;

namespace DSA_Project
{
    class Node
    {
        public Product Data;
        public Node Next;

        public Node(Product product)
        {
            Data = product;
            Next = null;
        }
    }

    public class ProductManager
    {
        private Node head;
        private const string CSV_FILE_PATH = "products_inventory.csv"; // File path for CSV

        public ProductManager()
        {
            // Load products from CSV when the program starts
            LoadProductsFromCSV();
        }

        public void AddProduct(Product product)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))
                {
                    temp.Data.Stock += product.Stock; // Update stock if product exists
                    Console.WriteLine($"Updated stock for {product.Name}: {temp.Data.Stock}");
                    return;
                }
                temp = temp.Next;
            }

            Node newNode = new Node(product);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }
        }

        public void DisplayProducts()
        {
            if (head == null)
            {
                Console.WriteLine("\nNo products available.");
                return;
            }

            Console.WriteLine("\nAvailable Products:");
            Node temp = head;
            while (temp != null)
            {
                temp.Data.DisplayProducts();
                temp = temp.Next;
            }
        }

        public Product GetProduct(string name)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return temp.Data;
                }
                temp = temp.Next;
            }
            return null;
        }

        public void AddProductFromUser()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price (in Rs): ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.Write("Invalid input. Enter a valid price: ");
            }

            Console.Write("Enter stock quantity: ");
            int stock;
            while (!int.TryParse(Console.ReadLine(), out stock) || stock < 0)
            {
                Console.Write("Invalid input. Enter a valid stock quantity: ");
            }

            AddProduct(new Product(name, price, stock));
            Console.WriteLine($"{name} added successfully!\n");

            // Save products to CSV after adding a new one
            SaveProductsToCSV();
        }

        // Method to load products from CSV file
        private void LoadProductsFromCSV()
        {
            if (File.Exists(CSV_FILE_PATH))
            {
                string[] lines = File.ReadAllLines(CSV_FILE_PATH);
                foreach (var line in lines)
                {
                    var data = line.Split(',');
                    if (data.Length == 3)
                    {
                        string name = data[0];
                        double price = double.Parse(data[1]);
                        int stock = int.Parse(data[2]);
                        AddProduct(new Product(name, price, stock));
                    }
                }
                Console.WriteLine("Products loaded from CSV.");
            }
            else
            {
                Console.WriteLine("No CSV file found. Starting with an empty inventory.");
            }
        }

        // Method to save products to CSV file
        private void SaveProductsToCSV()
        {
            using (StreamWriter sw = new StreamWriter(CSV_FILE_PATH))
            {
                Node temp = head;
                while (temp != null)
                {
                    sw.WriteLine($"{temp.Data.Name},{temp.Data.Price},{temp.Data.Stock}");
                    temp = temp.Next;
                }
            }
            Console.WriteLine("Products saved to CSV.");
        }
        public void DeleteProduct(string productName)
        {
            if (head == null)
            {
                Console.WriteLine("No products to delete.");
                return;
            }

            // If the product to be deleted is the head node
            if (head.Data.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
            {
                head = head.Next;
                Console.WriteLine($"{productName} has been deleted from the inventory.");
                return;
            }

            // Search for the product in the list
            Node temp = head;
            while (temp.Next != null)
            {
                if (temp.Next.Data.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    temp.Next = temp.Next.Next;
                    Console.WriteLine($"{productName} has been deleted from the inventory.");
                    return;
                }
                temp = temp.Next;
            }

            // If the product is not found
            Console.WriteLine($"{productName} not found in inventory.");
        }
    }
}
