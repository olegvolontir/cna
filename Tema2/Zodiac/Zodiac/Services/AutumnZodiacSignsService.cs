using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos;

namespace Zodiac.Services
{
    public class AutumnZodiacSignsService : AutumnZodiacSigns.AutumnZodiacSignsBase
    {
        private readonly ILogger<AutumnZodiacSignsService> _logger;
        public AutumnZodiacSignsService(ILogger<AutumnZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<AutumnZodiacSign> GetAutumnZodiacSign(AutumnZodiacSignRequest request, ServerCallContext context)
        {
            var sign = new AutumnZodiacSign();

            sign.Sign = "Autumn Zodiac Sign";

            return Task.FromResult(sign);
        }
    }
}
