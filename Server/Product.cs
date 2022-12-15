using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketServer
{
    public class Product
    {
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public Product( string name, string description, string category, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category;
            Price = price;
        }

        public Product()
        {

        }
    }
}
