using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace UserService
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<UserReply> GetUser(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserReply
            {
                Message = "Bob Villa"
            });
        }
    }
}
