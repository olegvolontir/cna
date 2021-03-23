using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace User
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new UserData.UserDataClient(channel);

            Console.WriteLine("Introduceti numele:");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti cnp:");
            string cnp = Console.ReadLine();

            var reply = await client.GetUserDataAsync(new SendUserData { Cnp = cnp, Name = nume });

            Console.WriteLine(reply.Message);
        }
    }
}
