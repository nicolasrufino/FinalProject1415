using System.Collections.Generic;

namespace FinalProject.Lib
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Order> OrderHistory { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            OrderHistory = new List<Order>();
        }

        public bool Login(string password)
        {
            return Password == password;
        }

        public void AddOrder(Order order)
        {
            OrderHistory.Add(order);
        }

        public void DisplayOrderHistory()
        {
            if (OrderHistory.Count == 0)
            {
                System.Console.WriteLine("No orders found.");
                return;
            }

            System.Console.WriteLine("Order History:");
            foreach (var order in OrderHistory)
            {
                System.Console.WriteLine($"Order Total: ${order.TotalCost}, Completed: {order.IsCompleted}");
            }
        }
    }
}
