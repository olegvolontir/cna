﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos.WinterZodiacSign;

namespace Zodiac.Services
{
    public class WinterZodiacSignsService : WinterZodiacSign.WinterZodiacSignBase
    {
        private readonly ILogger<WinterZodiacSignsService> _logger;

        public WinterZodiacSignsService(ILogger<WinterZodiacSignsService> logger)
        {
            _logger = logger;
        }

        public override Task<ZodiacSign> GetZodiacSign(InputDate request, ServerCallContext context)
        {
            ZodiacSign result = new ZodiacSign();

            result.Sign = "winter";

            return Task.FromResult(result);
        }
    }
}
