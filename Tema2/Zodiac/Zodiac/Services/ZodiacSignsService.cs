using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
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

            sign.Sign = "Zodiac Sign";

            return Task.FromResult(sign);
        }
    }
}
