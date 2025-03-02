using DSA_Project;
using System;

public class ShoppingCart
{
    private Product[] cart;
    private int[] quantities;
    private int count;

    public ShoppingCart(int size)
    {
        cart = new Product[size];
        quantities = new int[size];
        count = 0;
    }

    public void AddToCart(Product product, int quantity)
    {
        // Check if the product is already in the cart
        for (int i = 0; i < count; i++)
        {
            if (cart[i] == product)
            {
                quantities[i] += quantity; // Increase quantity if product exists
                Console.WriteLine($" {quantity} more {product.Name}(s) added to cart.");
                return;
            }
        }

        // If product is not in the cart, add it as a new item
        if (count < cart.Length)
        {
            cart[count] = product;
            quantities[count] = quantity;
            count++;
            Console.WriteLine($"{quantity} {product.Name}(s) added to cart.");
        }
        else
        {
            Console.WriteLine("Cart is full!");
        }
    }

    public void DisplayCart()
    {
        if (count == 0)
        {
            Console.WriteLine("Cart is empty.");
            return;
        }

        Console.WriteLine("\nShopping Cart:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{cart[i].Name} - Quantity: {quantities[i]}");
        }
    }

    // Get cart items as a tuple array of products and their quantities
    public (Product, int)[] CartItems()
    {
        (Product, int)[] items = new (Product, int)[count];
        for (int i = 0; i < count; i++)
        {
            items[i] = (cart[i], quantities[i]);
        }
        return items;
    }

    // Clear the cart after order is placed
    public void ClearCart()
    {
        cart = new Product[cart.Length];
        quantities = new int[quantities.Length];
        count = 0;
        Console.WriteLine("Cart cleared.");
    }
}
