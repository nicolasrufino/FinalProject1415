using System.Collections.Generic;

namespace FinalProject.Lib
{
    public class Order
    {
        public List<Product> Products { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsCompleted { get; set; }

        public Order(List<Product> products, decimal totalCost)
        {
            Products = products;
            TotalCost = totalCost;
            IsCompleted = false;
        }

        public void CompleteOrder()
        {
            IsCompleted = true;
        }
    }
}
