using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineMarketServer
{
    public class Server
    {
        
        private HttpListener server;
        private Database database;

        public Server(string serverName)
        {
            Console.Title = serverName;

            server = new HttpListener();  
            database = new Database();
        }

        public void Start()
        {

            server.Prefixes.Add("http://127.0.0.1:2222/");
            server.Prefixes.Add("http://127.0.0.1:2222/products/");
            server.Prefixes.Add("http://127.0.0.1:2222/search/");
            server.Prefixes.Add("http://127.0.0.1:2222/addProducts/");

            server.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                     Server is ready for connection...");

        }

       

        private async Task AcceptClient()
        {
            var context =await server.GetContextAsync();

            using StreamWriter writer = new StreamWriter(context.Response.OutputStream);
            using StreamReader reader = new StreamReader(context.Request.InputStream);



            if (context.Request.HttpMethod == "GET" && context.Request.RawUrl.ToLower().Contains("products"))
            {


                var jsonContent = JsonConvert.SerializeObject(database.GetProducts());

                await writer.WriteAsync(jsonContent);
                await writer.FlushAsync();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Client ga productlar ro'yhati uzatilindi!");

            }
            else if (context.Request.HttpMethod == "POST" && context.Request.RawUrl.ToLower().Contains("postproduct"))
            {

                var jsoncontent = await reader.ReadLineAsync();

                var product = JsonConvert.DeserializeObject<Product>(jsoncontent);

                database.Add(product);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Productlar ro'yhatiga product qoshildi! ");

            }
            else if (context.Request.HttpMethod == "GET" && context.Request.RawUrl.ToLower().Contains("search"))
            {
                var someThing = context.Request.RawUrl.Split('?')[1];
                var product = database.Find(someThing);
                if ( product.Count!= 0) 
                {
                    await writer.WriteLineAsync(JsonConvert.SerializeObject(product));
                    await writer.FlushAsync();
                }
                else
                {
                    await writer.WriteLineAsync("404");
                    await writer.FlushAsync();
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("So'rov bo'yicha productlar ro'yhati foydalanuvchiga uzatilindi!");
            }



        }

        public async Task  AcceptClientsAsync()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("                         Server is running ... ");
            while (true)
            {
                Task.Run(async () => await AcceptClient());
            }
        }


     


    }
}
