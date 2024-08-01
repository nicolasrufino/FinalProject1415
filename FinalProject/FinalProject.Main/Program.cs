using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Lib
{
    class Program
    {
        static List<Product> products = new List<Product>();
        static ShoppingCart cart = new ShoppingCart();

        static void Main(string[] args)
        {
            InitializeProducts();
            string choice;

            Console.Clear();
            Console.WriteLine("Welcome to RomanJeans E-store");
            Thread.Sleep(1000);
            Console.WriteLine("A brand new shopping experience");
            Thread.Sleep(2000);
            
            do
            {
                Console.Clear();
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Checkout");
                Console.WriteLine("4. Exit");
                Console.WriteLine("");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewProducts();
                        break;
                    case "2":
                        ViewCart();
                        break;
                    case "3":
                        Checkout();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for visiting. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            } while (choice != "4");
        }

        static void InitializeProducts()
        {
            var tShirtSizes = new List<Size>
            {
                new Size("XS", "Extra Small"),
                new Size("S", "Small"),
                new Size("M", "Medium"),
                new Size("L", "Large"),
                new Size("XL", "Extra Large")
            };

            products.Add(new Product("T-Shirt", 30m, tShirtSizes));

            var hoodieSizes = new List<Size>
            {
                new Size("XS", "Extra Small"),
                new Size("S", "Small"),
                new Size("M", "Medium"),
                new Size("L", "Large"),
                new Size("XL", "Extra Large")
            };

            products.Add(new Product("Hoodie", 50m, hoodieSizes));

            var jeanSizes = new List<Size>
            {
                new Size("30", "Size 30"),
                new Size("32", "Size 32"),
                new Size("34", "Size 34"),
                new Size("36", "Size 36"),
                new Size("38", "Size 38")
            };

            products.Add(new Product("Jeans", 80m, jeanSizes));
        }

        static void ViewProducts()
        {
            Console.Clear();
            Console.WriteLine("Products Available:");

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - ${product.Price}");
            }

            Console.WriteLine("Enter the product name to view details or type 'back' to return to the main menu:");
            string input = Console.ReadLine();

            if (input.ToLower() == "back")
                return;

            var selectedProduct = products.FirstOrDefault(p => p.Name.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (selectedProduct == null)
            {
                Console.WriteLine("Product not found.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"{selectedProduct.Name} - ${selectedProduct.Price}");
            Console.WriteLine("Available Sizes:");
            foreach (var productSize in selectedProduct.Sizes)
            {
                Console.WriteLine($"{productSize.Name} - {productSize.Description}");
            }

            Console.WriteLine("Enter the size you want to add to the cart or type 'back' to return to the products list:");
            string sizeName = Console.ReadLine();

            if (sizeName.ToLower() == "back")
                return;

            var selectedSize = selectedProduct.Sizes.FirstOrDefault(s => s.Name.Equals(sizeName, StringComparison.OrdinalIgnoreCase));
            if (selectedSize == null)
            {
                Console.WriteLine("Size not found.");
                Console.ReadKey();
                return;
            }

            try
            {
                cart.AddProduct(selectedProduct);
                Console.WriteLine($"Added {selectedProduct.Name} to the cart.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void ViewCart()
        {
            Console.Clear();
            cart.DisplayCart();

            string input = Console.ReadLine();

            if (input.ToLower() == "clear")
            {
                cart.ClearCart();
                Console.WriteLine("Cart has been cleared.");
            }
            else if (input.ToLower() == "checkout")
            {
                Checkout();
            }
            else if (input.ToLower() == "back")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Press any key to return to the main menu.");
            }

            Console.ReadKey();
        }

        static void Checkout()
        {
            Console.Clear();
            Console.WriteLine("Checkout:");

            if (cart.CartItems.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter your address for shipping:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter the tax amount:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal tax))
            {
                Console.WriteLine("Invalid tax amount.");
                return;
            }

            Console.WriteLine("Enter the shipping cost:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal shipping))
            {
                Console.WriteLine("Invalid shipping cost.");
                return;
            }

            cart.CalculateTotalCost(tax, shipping);
            Order newOrder = new Order(new List<Product>(cart.CartItems), cart.TotalCost);
            newOrder.CompleteOrder();

            Console.WriteLine("Order completed successfully.");
            Console.WriteLine($"Total Cost: ${newOrder.TotalCost}");
            cart.ClearCart();

            Console.ReadKey();
        }
    }
}
