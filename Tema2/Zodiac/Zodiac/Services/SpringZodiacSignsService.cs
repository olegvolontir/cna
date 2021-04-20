﻿using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Zodiac.Protos;
using System.Text.RegularExpressions;

namespace Zodiac.Services
{
    public class SpringZodiacSignsService : SpringZodiacSigns.SpringZodiacSignsBase
    {
        private readonly ILogger<SpringZodiacSignsService> _logger;
        private readonly string[] intervals;
        private string monthPatternReq;
        private string dayPatternReq;
        private string monthPatternText;
        private string dayPatternText;
        public SpringZodiacSignsService(ILogger<SpringZodiacSignsService> logger)
        {
            _logger = logger;
            intervals = File.ReadAllLines(@"Resources/SpringZodiacSigns.txt");
            monthPatternReq = @"(\d\d|\d)/";
            dayPatternReq = @"/(\d\d|\d)/";
            monthPatternText = @"(\d\d|\d)/";
            dayPatternText = @"/(\d\d|\d)";
        }

        public override Task<SpringZodiacSign> GetSpringZodiacSign(SpringZodiacSignRequest request, ServerCallContext context)
        {
            var sign = new SpringZodiacSign();

            var matchMonth = Regex.Match(request.Date, monthPatternReq);
            var matchDay = Regex.Match(request.Date, dayPatternReq);

            int requestMonth = int.Parse(matchMonth.Value.Substring(0, matchMonth.Value.Length - 1));
            int requestDay = int.Parse(matchDay.Value.Substring(1, matchDay.Value.Length - 2));
            string matchSign = "default";

            foreach (string line in intervals)
            {
                matchMonth = Regex.Match(line, monthPatternText);
                int month = int.Parse(matchMonth.Value.Substring(0, matchMonth.Value.Length - 1));

                var days = Regex.Matches(line, dayPatternText)
                             .OfType<Match>()
                             .Select(m => m.Groups[0].Value.Substring(1, m.Value.Length - 1))
                             .ToArray();

                if (requestMonth == month && requestDay >= int.Parse(days[0]) && requestDay <= int.Parse(days[1]))
                {
                    matchSign = Regex.Match(line, @"\w*$").Value;
                }
            }

            sign.Sign = matchSign;

            return Task.FromResult(sign);
        }
    }
}
