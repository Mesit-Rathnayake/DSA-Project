using DSA_Project;
using System;
using static DSA_Project.OrderNode;

class Program
{
    static void Main()
    {
        ProductManager productManager = new ProductManager();
        ShoppingCart cart = new ShoppingCart(10);
        OrderQueue orderQueue = new OrderQueue();

        while (true)
        {
            Console.WriteLine("1. Add Product to Catalog");
            Console.WriteLine("2. Display Products");
            Console.WriteLine("3. Add Product to Cart");
            Console.WriteLine("4. Display Cart");
            Console.WriteLine("5. Place Order");
            Console.WriteLine("6. Process Order");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 7)
            {
                Console.Write("Invalid choice. Please enter a number between 1 and 7: ");
            }

            switch (choice)
            {
                case 1:
                    productManager.AddProductFromUser();
                    break;

                case 2:
                    productManager.DisplayProducts();
                    break;

                case 3:
                    Console.Write("Enter product name to add to cart: ");
                    string productName = Console.ReadLine();
                    Product product = productManager.GetProduct(productName);

                    if (product != null)
                    {
                        cart.AddToCart(product);
                        Console.WriteLine($"{product.Name} added to cart.");
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Displaying Cart:");
                    cart.DisplayCart();
                    break;

                case 5:
                    Console.WriteLine("Place Order: ");
                    foreach (var item in cart.CartItems())
                    {
                        orderQueue.Enqueue(item);
                    }
                    cart.ClearCart();
                    break;

                case 6:
                    Console.WriteLine("Processing Order...");
                    orderQueue.ProcessOrder();
                    break;

                case 7:
                    return; // Exit the program
            }
        }
    }
}
