using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketServer
{
    public class Database
    {
        private List<Product> products;

        public Database()
        {
            products = new List<Product>()
            {
                new Product("Olma","qizil Golden navli","Meva",2000),
                new Product("Nok","Xitoy noki","Meva",40000),
                new Product("Iphone X","Oq 128/8 gbayt","Telephone",200),
                new Product("Iphone 11","Gold 256/12","Telephone",400),
                new Product("Iphone 11 pro","Gold 64/4","Telephone",500),
                new Product("Iphone 11 pro max","Oq 256/12","Telephone",600),
                new Product("Iphone 14 pro max","Gold 512/16","Telephone",1400),
                new Product("Samsung 21 ultra","Gold 512/16","Telephone",1000),
                new Product("Samsung 22 ultra","Gold 512/16","Telephone",1300),
                new Product("Redmi Note 11","Qora 512/16","Telephone",800),
                new Product("Xiomi T12 ","Gold 512/16","Telephone",600),
                new Product("Redmi Note 11 pro", "Gold 512/16", "Telephone", 1000),
                new Product("Dell G 15 5511","Mokri Gaming core i5","NoteBook",1000),
                new Product("Hp Pavillion G15","Mokri Gaming core i5","NoteBook",9000),
                new Product("Asus Tuf","Mokri Gaming core i5","NoteBook",1100),
                new Product("Acer Nitro 5","Metalika Gaming core i5","NoteBook",1000),
                new Product("Hp pavillion","Mokri  core i5","NoteBook",600),
                new Product("Samsung Tv ","Smart Tv 32 ","Televizor",300),
                new Product("Shivaki Tv ","Smart Tv 32 ","Televizor",200),
                new Product("Vovo Tv ","Smart Tv 32 ","Televizor",180),
                new Product("Samsung Tv ","Smart Tv 53 ","Televizor",450),
                new Product("Samsung Galaxy C11 ","oq 128/8 ","Telephone",300),
                new Product("SmartWatch redmi","Aqlli soat","Watch",60),
                new Product("SmartWatch iphone","Aqlli soat","Watch",200),
                new Product("SmartWatch samsung","Aqlli soat","Watch",80),
                
            };
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Product> Find(string pro)
        {
            string searchingPro = pro.ToLower();
            var expectedProducts = new List<Product>();

            foreach (var product in products)
            {
                string name = product.Name.ToLower();
                string discription = product.Description.ToLower();
                string category = product.Category.ToLower();

                if (name.Contains(searchingPro) || discription.Contains(searchingPro) || category.Contains(searchingPro))
                {
                    expectedProducts.Add(product);
                }
            }

            return expectedProducts;
        }

    }
}
