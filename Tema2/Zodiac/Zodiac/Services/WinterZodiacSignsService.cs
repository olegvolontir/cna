using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos;

namespace Zodiac.Services
{
    public class WinterZodiacSignsService : WinterZodiacSigns.WinterZodiacSignsBase
    {
        private readonly ILogger<WinterZodiacSignsService> _logger;
        public WinterZodiacSignsService(ILogger<WinterZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<WinterZodiacSign> GetWinterZodiacSign(WinterZodiacSignRequest request, ServerCallContext context)
        {
            var sign = new WinterZodiacSign();

            sign.Sign = "Winter Zodiac Sign";

            return Task.FromResult(sign);
        }
    }
}
