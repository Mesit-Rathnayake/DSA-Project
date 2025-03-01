using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class SortingAndSearching
    {
        public static void BubbleSort(Product[] products)
        {
            int n = products.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (products[j].Price > products[j + 1].Price)
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }
        }
        public static int BinarySearch(Product[] products, string target)
        {
            int left = 0, right = products.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (products[mid].Name == target)
                {
                    return mid;
                }
                if (String.Compare(products[mid].Name, target) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
