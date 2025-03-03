using System;

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

                while (front != null)
                {
                    // Check if there's enough stock to fulfill the order
                    if (front.OrderProduct.Stock >= front.Quantity)
                    {
                        front.OrderProduct.Stock -= front.Quantity; // Reduce stock
                        double orderCost = front.OrderProduct.Price * front.Quantity;
                        totalAmount += orderCost;
                        Console.WriteLine($"Processed: {front.Quantity} x {front.OrderProduct.Name} | Cost: {orderCost:C} | Remaining Stock: {front.OrderProduct.Stock}");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough stock for {front.OrderProduct.Name}. Order skipped.");
                    }

                    front = front.Next;
                }

                rear = null; // Queue is empty now
                Console.WriteLine($"\nTotal Order Amount: {totalAmount:C}");
            }

            internal void Enqueue((Product, int) item)
            {
                throw new NotImplementedException();
            }
        }
    }
}
