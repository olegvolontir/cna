using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos.SummerZodiacSign;

namespace Zodiac.Services
{
    public class SummerZodiacSignsService : SummerZodiacSign.SummerZodiacSignBase
    {
        private readonly ILogger<SummerZodiacSignsService> _logger;

        public SummerZodiacSignsService(ILogger<SummerZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacSign> GetZodiacSign(InputDate request, ServerCallContext context)
        {
            ZodiacSign result = new ZodiacSign();

            result.Sign = "summer";

            return Task.FromResult(result);
        }
    }
}
