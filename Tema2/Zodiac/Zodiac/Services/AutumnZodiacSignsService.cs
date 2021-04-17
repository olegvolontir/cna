using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos.AutumnZodiacSign;

namespace Zodiac.Services
{
    public class AutumnZodiacSignsService : AutumnZodiacSign.AutumnZodiacSignBase
    {
        private readonly ILogger<AutumnZodiacSignsService> _logger;

        public AutumnZodiacSignsService(ILogger<AutumnZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacSign> GetZodiacSign(InputDate request, ServerCallContext context)
        {
            ZodiacSign result = new ZodiacSign();

            result.Sign = "autumn";

            return Task.FromResult(result);
        }
    }
}
