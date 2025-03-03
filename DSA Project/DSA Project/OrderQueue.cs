using System;
using System.Globalization;

namespace DSA_Project
{
    class OrderNode
    {
        public Product OrderProduct;
        public int Quantity;
        public OrderNode Next;

        public OrderNode(Product product, int quantity)
        {
            OrderProduct = product;
            Quantity = quantity;
            Next = null;
        }

        public class OrderQueue
        {
            private OrderNode front, rear;

            public void Enqueue(Product product, int quantity)
            {
                OrderNode newNode = new OrderNode(product, quantity);
                if (front == null)
                {
                    front = newNode;
                    rear = newNode;
                }
                else
                {
                    rear.Next = newNode;
                    rear = newNode;
                }
                Console.WriteLine($"{quantity} x {product.Name} added to the order queue.");
            }

            public void ProcessOrder()
            {
                if (front == null)
                {
                    Console.WriteLine("No orders to process.");
                    return;
                }

                double totalAmount = 0;
                CultureInfo lkrCulture = new CultureInfo("en-LK"); // Sri Lankan currency format

                while (front != null)
                {
                    if (front.OrderProduct.Stock >= front.Quantity)
                    {
                        front.OrderProduct.Stock -= front.Quantity;
                        double orderCost = front.OrderProduct.Price * front.Quantity;
                        totalAmount += orderCost;
                        Console.WriteLine($"Processed: {front.Quantity} x {front.OrderProduct.Name} | Cost: {orderCost.ToString("C", lkrCulture)} | Remaining Stock: {front.OrderProduct.Stock}");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough stock for {front.OrderProduct.Name}. Order skipped.");
                    }

                    front = front.Next;
                }

                rear = null;
                Console.WriteLine($"\nTotal Order Amount: {totalAmount.ToString("C", lkrCulture)}");
            }

            internal void Enqueue((Product, int) item)
            {
                throw new NotImplementedException();
            }
        }
    }
}
