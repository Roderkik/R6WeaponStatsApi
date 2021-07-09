using System.Collections.Generic;

namespace RainbowStatsAPI.DTOs
{
    public class OperatorDto
    {
        public string Name { get; set; }
        public ICollection<WeaponDto> Weapons { get; set; }
    }
}