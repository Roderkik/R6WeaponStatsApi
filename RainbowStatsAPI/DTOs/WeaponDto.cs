using System.Collections.Generic;
using System.Security.Cryptography;

namespace RainbowStatsAPI.DTOs
{
    public class WeaponDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Slot { get; set; }
        public int Rpm { get; set; }
        public int[] DamageRanges { get; set; }
        public ICollection<OperatorDto> Operators { get; set; }
    }
}