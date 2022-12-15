using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace httpClient
{
    public static class Menu
    {

        public static void SelectCommand(out int command)
        {
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("Menu\n\n1.Search product\n2.Post product\n3.Print Products\n4.Clear Console");
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("\nSelect Command : ");

            Console.ForegroundColor = ConsoleColor.White;
            var input = int.Parse(Console.ReadLine());

            command = input;
        }

        public static Product InputPostFromConsole()
        {
            Console.Write("Product Name : ");
            var name = Console.ReadLine();

            Console.Write("Product Price : ");
            var price =decimal.Parse(Console.ReadLine());

            Console.Write("Product Category : ");
            var category = Console.ReadLine();

            Console.Write("Product Description : ");
            var description = Console.ReadLine();



            return new Product() { Name = name, Price = price,Category = category, Description = description };
        }


        public static void PrintProducts(List<Product>products)
        {

            var counts = new List<int>();
            foreach (var product in products)
            {
                string myProduct = $"| Id : {product.Id} |  Name : {product.Name} | " +
                    $" Category : {product.Category} |  Description : {product.Description} |  Price : {product.Price} |";

                int count = myProduct.Count();

                counts.Add(count);
                

            }

            foreach (var product in products)
            {
                string myProduct = $"| Id : {product.Id} |  Name : {product.Name} | " +
                $" Category : {product.Category} |  Description : {product.Description} |  Price : {product.Price} ";
                
                var symbol = new StringBuilder();

                int count = counts.Max();

                for (int i = 0; i < count; i++)
                {
                    symbol.Append('-');
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(symbol.ToString());
                Console.WriteLine(myProduct);
                Console.WriteLine(symbol.ToString());
                Console.ForegroundColor = ConsoleColor.White;

            }
        }



        public static void PrintProduct(Product product)
        {
            var stringProduct = $"| Id : {product.Id} |  Name : {product.Name} | " +
            $" Category : {product.Category} |  Description : {product.Description} |  Price : {product.Price} |";

            int count = stringProduct.Count();

            var symbol = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                symbol.Append('-');
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(symbol.ToString());
            Console.WriteLine(stringProduct);
            Console.WriteLine(symbol.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
