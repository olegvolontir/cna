using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserData
{
    public class UserDataService : UserData.UserDataBase
    {
        private Regex cnpPattern = new Regex(@"^[1-8]\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{6}$");

        private readonly ILogger<UserDataService> _logger;

        public UserDataService(ILogger<UserDataService> logger)
        {
            _logger = logger;
        }

        public override Task<Reply> GetUserData(SendUserData request, ServerCallContext context)
        {
            Reply reply = new Reply();

            Console.WriteLine("User's name: " + request.Name);
            Console.WriteLine("User's CNP: " + request.Cnp);

            if (cnpPattern.IsMatch(request.Cnp))
            {
                reply.Message = "Hello " + request.Name;
            }
            else
            {
                reply.Message = "Wrong CNP";
            }

            return Task.FromResult(reply);
        }
    }
}