using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

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
            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine("Product name cannot be empty.");
                return;
            }

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
                SaveProductsToCSV(); // Save after deletion
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
                    SaveProductsToCSV(); // Save after deletion
                    return;
                }
                temp = temp.Next;
            }

            // If the product is not found
            Console.WriteLine($"{productName} not found in inventory.");
        }

        //MergeSort
        /*
        public void SortProductsByPrice()
        {
            if (head == null)
            {
                Console.WriteLine("No products to sort.");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Convert linked list to a List
            List<Product> productList = new List<Product>();
            Node temp = head;
            while (temp != null)
            {
                productList.Add(temp.Data);
                temp = temp.Next;
            }

            // Apply MergeSort
            MergeSort(productList);

            // Rebuild the linked list
            head = null;
            foreach (var product in productList)
            {
                AddProduct(product); // Reuse the AddProduct method to insert them back
            }

            stopwatch.Stop();
            Console.WriteLine($"Products sorted by price using MergeSort in {stopwatch.ElapsedMilliseconds} ms.");
        }

        private void MergeSort(List<Product> productList)
        {
            if (productList.Count <= 1)
                return;

            int mid = productList.Count / 2;
            List<Product> left = productList.Take(mid).ToList();
            List<Product> right = productList.Skip(mid).ToList();

            MergeSort(left);
            MergeSort(right);

            Merge(productList, left, right);
        }

        private void Merge(List<Product> productList, List<Product> left, List<Product> right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i].Price <= right[j].Price)
                {
                    productList[k++] = left[i++];
                }
                else
                {
                    productList[k++] = right[j++];
                }
            }

            while (i < left.Count)
            {
                productList[k++] = left[i++];
            }

            while (j < right.Count)
            {
                productList[k++] = right[j++];
            }
        }*/


        //QuickSort
        public void SortProductsByPrice()
        {
            if (head == null)
            {
                Console.WriteLine("No products to sort.");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Convert linked list to a List
            List<Product> productList = new List<Product>();
            Node temp = head;
            while (temp != null)
            {
                productList.Add(temp.Data);
                temp = temp.Next;
            }

            // Apply QuickSort
            QuickSort(productList, 0, productList.Count - 1);

            // Rebuild the linked list
            head = null;
            foreach (var product in productList)
            {
                AddProduct(product); // Reuse the AddProduct method to insert them back
            }

            stopwatch.Stop();
            Console.WriteLine($"Products sorted by price using QuickSort in {stopwatch.ElapsedMilliseconds} ms.");
        }

        private void QuickSort(List<Product> productList, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(productList, low, high);

                QuickSort(productList, low, pi - 1);  // Sort left
                QuickSort(productList, pi + 1, high); // Sort right
            }
        }

        private int Partition(List<Product> productList, int low, int high)
        {
            Product pivot = productList[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (productList[j].Price < pivot.Price)
                {
                    i++;
                    Swap(productList, i, j);
                }
            }
            Swap(productList, i + 1, high);
            return i + 1;
        }

        private void Swap(List<Product> productList, int i, int j)
        {
            var temp = productList[i];
            productList[i] = productList[j];
            productList[j] = temp;
        }

        //BubbleSort

        /*
        public void SortProductsByPrice()
        {
            if (head == null)
            {
                Console.WriteLine("No products to sort.");
                return;
            }

            Stopwatch stopwatch = new Stopwatch(); // Create a stopwatch to measure time
            stopwatch.Start(); // Start the stopwatch

            // Convert linked list to a List
            List<Product> productList = new List<Product>();
            Node temp = head;
            while (temp != null)
            {
                productList.Add(temp.Data);
                temp = temp.Next;
            }

            // Sort by price
            var sortedProducts = productList.OrderBy(p => p.Price).ToList();

            // Rebuild the linked list
            head = null;
            foreach (var product in sortedProducts)
            {
                AddProduct(product); // Reuse the AddProduct method to insert them back
            }

            stopwatch.Stop(); // Stop the stopwatch after sorting is complete
            Console.WriteLine($"Products sorted by price in {stopwatch.ElapsedMilliseconds} ms.");
        }*/
    }
}
