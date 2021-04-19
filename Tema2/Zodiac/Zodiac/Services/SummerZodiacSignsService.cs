using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos;

namespace Zodiac.Services
{
    public class SummerZodiacSignsService : SummerZodiacSigns.SummerZodiacSignsBase
    {
        private readonly ILogger<SummerZodiacSignsService> _logger;
        public SummerZodiacSignsService(ILogger<SummerZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<SummerZodiacSign> GetSummerZodiacSign(SummerZodiacSignRequest request, ServerCallContext context)
        {
            var sign = new SummerZodiacSign();

            sign.Sign = "Summer Zodiac Sign";

            return Task.FromResult(sign);
        }
    }
}
