

using Newtonsoft.Json;
using OnlineMarketServer;

try
{


    Server server = new Server("My Online Market Server");

    server.Start();

    await server.AcceptClientsAsync();


    //server.Finished();

    Console.ReadKey();

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}