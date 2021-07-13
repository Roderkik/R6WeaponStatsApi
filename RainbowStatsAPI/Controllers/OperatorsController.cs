using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RainbowStatsAPI.DTOs;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.Controllers
{
    public class OperatorsController : BaseApiController
    {
        public OperatorsController(RainbowStatsContext rainbowStatsContext) : base(rainbowStatsContext)
        {
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            Operator @operator = await context.Operators
                .Include(o => o.Weapons)
                .FirstOrDefaultAsync(o => EF.Functions.ILike(o.Name, name));

            if (@operator == null) return NotFound();

            return Ok(OperatorDto.Get(@operator));
        }
    }
}