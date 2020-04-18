using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace toggle_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToggleController : ControllerBase
    {
        private readonly ILogger<ToggleController> _logger;

        public ToggleController(ILogger<ToggleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Toggle> Get()
        {
            return new List<Toggle> {
                new Toggle {
                Name = "MyCoolFeature",
                IsReleased = false
                }
            };
        }
    }
}
