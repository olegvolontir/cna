using System;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace ZodiacClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ZodiacSigns.ZodiacSignsClient(channel);

            var sign = await client.GetZodiacSignAsync(new ZodiacSignRequest { Date = "spring" });
            Console.WriteLine(sign.Sign);
        }
    }
}
