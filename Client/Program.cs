
using httpClient;
using Newtonsoft.Json;


try
{
    using HttpClient client = new HttpClient();

    while (true)
    {
        Menu.SelectCommand(out int command);

        if(command==1) 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter your searching product : ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            string searchingWord = Console.ReadLine();
            Console.ForegroundColor= ConsoleColor.White;

            string searchUrl = $"http://127.0.0.1:2222/search?{searchingWord}";

            //var content = new StringContent(searchingWord);
            //var response = await client.PostAsync(searchUrl, content);

            // var stringResponse = response.Content.ReadAsStringAsync().Result;

            var Response = await client.GetAsync(searchUrl);

            string result = await Response.Content.ReadAsStringAsync();
            if (result == "404\r\n")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Natija : Not Found ");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                var product = JsonConvert.DeserializeObject<List<Product>>(result);
                
                Menu.PrintProducts(product);

            }

            

        }

        else if(command==2)
        {
           string postProductUrl = $"http://127.0.0.1:2222/postProduct/";
           var product =  Menu.InputPostFromConsole();

            var content = new StringContent(JsonConvert.SerializeObject(product));

            var response = await client.PostAsync(postProductUrl, content);

            
            if((int)response.StatusCode == 200)
            {
                Console.WriteLine("Product successfully added to Server!\n");
            }
        }

        else if(command == 3)
        {
            string urlProducts = "http://127.0.0.1:2222/products/";

            var result = await client.GetAsync(urlProducts);

            var stringResult = await result.Content.ReadAsStringAsync();

            var listProducts = JsonConvert.DeserializeObject<List<Product>>(stringResult);

            Menu.PrintProducts(listProducts);
        }
        else if(command == 4 )
        {
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Incorrect command , please select correect command!\n");
        }
        

    }

}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}










//string response = await client.GetStringAsync(url);

//var objects = JsonSerializer.Deserialize<List<ClassA>>(response);


//Console.WriteLine(response + " nomli xabar servedan keldi");

/*foreach (var item in objects)
{
    Console.WriteLine($"id : {item.Id}; UserId : {item.UserId}; Body : {item.Body}");
}*/


