using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Zodiac.Protos;

namespace Zodiac.Services
{
    public class ZodiacSignsService : ZodiacSigns.ZodiacSignsBase
    {
        private Regex pattern = new Regex(@"^(\d\d|\d)/");
        private readonly ILogger<ZodiacSignsService> _logger;
        public ZodiacSignsService(ILogger<ZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacSign> GetZodiacSign(ZodiacSignRequest request, ServerCallContext context)
        {
            var sign = new ZodiacSign();
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var match = pattern.Match(request.Date);
            int month = int.Parse(match.Value.Substring(0, match.Length - 1));

            if (month==1||month==2||month==12)
            {
                var winterClient = new WinterZodiacSigns.WinterZodiacSignsClient(channel);
                sign.Sign = winterClient.GetWinterZodiacSign(new WinterZodiacSignRequest { Date = request.Date }).Sign;
            }
            else if (month>2 && month<6)
            {
                var springClient = new SpringZodiacSigns.SpringZodiacSignsClient(channel);
                sign.Sign = springClient.GetSpringZodiacSign(new SpringZodiacSignRequest { Date = request.Date }).Sign;
            }
            else if (month>5 && month <9)
            {
                var summerClient = new SummerZodiacSigns.SummerZodiacSignsClient(channel);
                sign.Sign = summerClient.GetSummerZodiacSign(new SummerZodiacSignRequest { Date = request.Date }).Sign;
            }
            else if (month>8 && month <12)
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
