using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Zodiac.Protos;

namespace Zodiac.Services
{
    public class ZodiacSignsService : ZodiacSigns.ZodiacSignsBase
    {
        private readonly ILogger<ZodiacSignsService> _logger;
        public ZodiacSignsService(ILogger<ZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacSign> GetZodiacSign(ZodiacSignRequest request, ServerCallContext context)
        {
            var sign = new ZodiacSign();
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            if(request.Date == "winter")
            {
                var winterClient = new WinterZodiacSigns.WinterZodiacSignsClient(channel);
                sign.Sign = winterClient.GetWinterZodiacSign(new WinterZodiacSignRequest { Date = request.Date }).Sign;
            }
            else if (request.Date == "spring")
            {
                var springClient = new SpringZodiacSigns.SpringZodiacSignsClient(channel);
                sign.Sign = springClient.GetSpringZodiacSign(new SpringZodiacSignRequest { Date = request.Date }).Sign;
            }
            else if (request.Date == "summer")
            {
                var summerClient = new SummerZodiacSigns.SummerZodiacSignsClient(channel);
                sign.Sign = summerClient.GetSummerZodiacSign(new SummerZodiacSignRequest { Date = request.Date }).Sign;
            }
            else if (request.Date == "autumn")
            {
                var autumnClient = new AutumnZodiacSigns.AutumnZodiacSignsClient(channel);
                sign.Sign = autumnClient.GetAutumnZodiacSign(new AutumnZodiacSignRequest { Date = request.Date }).Sign;
            }
            else
            {
                sign.Sign = "err";
            }

            return Task.FromResult(sign);
        }
    }
}
