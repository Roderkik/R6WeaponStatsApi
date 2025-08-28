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
        public WeaponsController(RainbowStatsContext rainbowStatsContext) : base(rainbowStatsContext)
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
                .FirstOrDefaultAsync(w => EF.Functions.Like(w.Name.ToLower(), name.ToLower()));

            if (weapon == null)
            {
                return NotFound();
            }

            return Ok(WeaponDto.Get(weapon));
        }

        /// <summary>
        /// Returns relevant weapons 
        /// </summary>
        /// <param name="name">Name of weapon</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{name}/Relevant")]
        public async Task<IActionResult> Relevant(string name)
        {
            Weapon weapon = await context.Weapons
                .Where(w => EF.Functions.Like(w.Name.ToLower(), name.ToLower()))
                .Include(w => w.Operators)
                .ThenInclude(o => o.Weapons)
                .FirstOrDefaultAsync();

            if (weapon == null) return NotFound();

            ICollection<Weapon> weapons = new List<Weapon>();

            foreach (Operator @operator in weapon.Operators)
            {
                foreach (Weapon relevantWeapon in @operator.Weapons)
                {
                    if (relevantWeapon.Slot == weapon.Slot &&
                        !weapons.Contains(relevantWeapon) && 
                        relevantWeapon != weapon)
                    {
                        weapons.Add(relevantWeapon);   
                    }
                }
            }

            return Ok(WeaponDto.Index(weapons));
        }
    }
}