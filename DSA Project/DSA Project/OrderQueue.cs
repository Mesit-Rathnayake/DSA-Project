using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    class OrderNode
    {
        public Product OrderProduct;
        public OrderNode Next;

        public OrderNode(Product product)
        {
            OrderProduct = product;
            Next = null;
        }
        public class OrderQueue
        {
            private OrderNode front, rear;
            public void Enqueue(Product product)
            {
                OrderNode newNode = new OrderNode(product);
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
                Console.WriteLine($"{product.Name}Product added to the order queue");
            }
            public void ProcessOrder()
            {
                if (front == null)
                {
                    Console.WriteLine("No orders to process");
                    return;
                }
                else
                {
                    Console.WriteLine($"{front.OrderProduct.Name} Order processed");
                    front = front.Next;
                    if (front == null)
                    {
                        rear = null;
                    }
                }
            }
        }
    }
}
