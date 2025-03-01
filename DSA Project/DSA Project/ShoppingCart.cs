using DSA_Project;

public class ShoppingCart
{
    private Product[] cart;
    private int count;

    public ShoppingCart(int size)
    {
        cart = new Product[size];
        count = 0;
    }

    public void AddToCart(Product product)
    {
        if (count < cart.Length)
        {
            cart[count] = product;
            count++;
        }
        else
        {
            Console.WriteLine("Cart is full");
        }
    }

    public void DisplayCart()
    {
        if (count == 0)
        {
            Console.WriteLine("Cart is empty.");
            return;
        }
        for (int i = 0; i < count; i++)
        {
            cart[i].DisplayProducts();
        }
    }

    // New method to retrieve cart items
    public Product[] CartItems()
    {
        Product[] items = new Product[count];
        Array.Copy(cart, items, count);
        return items;
    }

    // Clear the cart after order is placed
    public void ClearCart()
    {
        cart = new Product[cart.Length];
        count = 0;
    }
}
