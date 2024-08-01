using System.Collections.Generic;

namespace FinalProject.Lib
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Size> Sizes { get; set; }
        
        public Product(string name, decimal price, List<Size> sizes)
        {
            Name = name;
            Price = price;
            Sizes = sizes;
        }
    }

    public class Size
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Size(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
