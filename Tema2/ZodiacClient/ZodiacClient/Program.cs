using System;
using Grpc.Net.Client;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ZodiacClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DateValidation dateValidation = new DateValidation();

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ZodiacSigns.ZodiacSignsClient(channel);
            bool finished = false;

            while (!finished)
            {
                Console.WriteLine("Write a date (mm/dd/yyyy or (m/d/yyyy):");
                string input = Console.ReadLine();

                if (dateValidation.IsDateValid(input))
                {
                    ZodiacSign sign = await client.GetZodiacSignAsync(new ZodiacSignRequest { Date = input });
                    Console.WriteLine("The zodiac sign corespoding to the date: " + sign.Sign);
                }

                Console.WriteLine("1.Continue\n2.Exit");
                int choice = int.Parse(Console.ReadLine());
                if(choice==2)
                {
                    finished = true;
                }
            }
        }
    }
}
