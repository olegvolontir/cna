using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos.SpringZodiacSign;

namespace Zodiac.Services
{
    public class SpringZodiacSignsService : SpringZodiacSign.SpringZodiacSignBase
    {
        private readonly ILogger<SpringZodiacSignsService> _logger;

        public SpringZodiacSignsService(ILogger<SpringZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacSign> GetZodiacSign(InputDate request, ServerCallContext context)
        {
            ZodiacSign result = new ZodiacSign();

            result.Sign = "spring";

            return Task.FromResult(result);
        }
    }
}
