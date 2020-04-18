using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using UserService;

namespace ToggleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToggleController : ControllerBase
    {
        private readonly ILogger<ToggleController> _logger;
        private readonly IConfiguration Configuration;
        private ILoggerFactory _loggerFactory;

        public ToggleController(
            ILogger<ToggleController> logger,
            IConfiguration configuration,
            ILoggerFactory loggerFactory
        )
        {
            _logger = logger;
            Configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<Toggle>> GetAsync()
        {
            var userServiceUrl = Configuration["UserServiceUrl"];

            Console.Out.WriteLine("GRPC Endpoint: " + userServiceUrl);

            try
            {
                using var channel = GrpcChannel.ForAddress(userServiceUrl, new GrpcChannelOptions { LoggerFactory = _loggerFactory });
                var client = new User.UserClient(channel);
                var reply = await client.GetUserAsync(new UserRequest { Name = "1" });
                return new List<Toggle> {
                    new Toggle {
                    Name = "MyCoolFeature",
                    IsReleased = false,
                    Viewers = new List<string> { reply.Message }
                    }
                };
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Toggle Exception");
                Console.Out.Write(ex);
                throw;
            }
        }
    }
}
