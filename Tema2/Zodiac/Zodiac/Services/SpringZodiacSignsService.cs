using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos;

namespace Zodiac.Services
{
    public class SpringZodiacSignsService : SpringZodiacSigns.SpringZodiacSignsBase
    {
        private readonly ILogger<SpringZodiacSignsService> _logger;
        public SpringZodiacSignsService(ILogger<SpringZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<SpringZodiacSign> GetSpringZodiacSign(SpringZodiacSignRequest request, ServerCallContext context)
        {
            var sign = new SpringZodiacSign();

            sign.Sign = "Spring Zodiac Sign";

            return Task.FromResult(sign);
        }
    }
}
