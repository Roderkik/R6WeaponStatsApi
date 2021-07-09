using Microsoft.AspNetCore.Mvc;

namespace RainbowStatsAPI.Controllers
{
    [ApiController]
    [Route("Api/v1/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly RainbowStatsContext context;
        public BaseApiController(RainbowStatsContext rainbowStatsContext)
        {
            context = rainbowStatsContext;
        }
    }
}
