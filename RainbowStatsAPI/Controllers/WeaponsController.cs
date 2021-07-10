using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RainbowStatsAPI.DTOs;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.Controllers
{
    public class WeaponsController : BaseApiController
    {
        public WeaponsController(RainbowStatsContext rainbowStatsContext): base(rainbowStatsContext)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(WeaponDto.Index(await context.Weapons.ToListAsync()));
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            Weapon weapon = await context.Weapons
                .Include(w => w.Operators)
                .FirstOrDefaultAsync(w => EF.Functions.ILike(w.Name, name));

            if (weapon == null)
            {
                return NotFound();
            }

            return Ok(WeaponDto.Get(weapon));
        }
    }
}
