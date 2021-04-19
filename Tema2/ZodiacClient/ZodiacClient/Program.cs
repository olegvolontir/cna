using System;
using Grpc.Net.Client;
using System.Threading.Tasks;

namespace ZodiacClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DateValidation dateValidation = new DateValidation();

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ZodiacSigns.ZodiacSignsClient(channel);

            string input = Console.ReadLine();

            if (dateValidation.IsDateValid(input))
            {
                ZodiacSign sign = await client.GetZodiacSignAsync(new ZodiacSignRequest { Date = input });
                Console.WriteLine(sign.Sign);
            }
        }
    }
}
