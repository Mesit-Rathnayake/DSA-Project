using System;

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

            Console.Write("Enter product price: ");
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
        }
    }
}
