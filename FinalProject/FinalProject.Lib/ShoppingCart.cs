using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Lib
{
    public class ShoppingCart
    {
        public List<Product> CartItems { get; private set; } = new List<Product>();
        public decimal TotalCost { get; private set; }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            CartItems.Add(product);
            CalculateTotalCost();
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            CartItems.Remove(product);
            CalculateTotalCost();
        }

        public void ClearCart()
        {
            CartItems.Clear();
            TotalCost = 0;
        }

        public void CalculateTotalCost(decimal tax = 0, decimal shipping = 0)
        {
            TotalCost = CartItems.Sum(p => p.Price) + tax + shipping;
        }

        public void DisplayCart()
        {
            Console.Clear();
            Console.WriteLine("Your Cart:");

            if (CartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
            }
            else
            {
                foreach (var item in CartItems)
                {
                    Console.WriteLine($"{item.Name}: Price ${item.Price}");
                }
                Console.WriteLine($"Total Cost: ${TotalCost}");
            }

            Console.WriteLine("Enter 'checkout' to proceed or 'clear' to empty the cart:");
        }
    }
}
