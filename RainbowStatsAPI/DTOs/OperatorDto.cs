using System.Collections.Generic;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.DTOs
{
    public class OperatorDto
    {
        public string Name { get; set; }
        public ICollection<WeaponDto> Weapons { get; set; }

        public static OperatorDto Get(Operator @operator)
        {
            var weaponDtos = new List<WeaponDto>();

            foreach (Weapon weapon in @operator.Weapons)
                weaponDtos.Add(new WeaponDto
                {
                    Action = weapon.Action,
                    DamageRanges = weapon.DamageRanges,
                    Name = weapon.Name,
                    Rpm = weapon.Rpm,
                    Slot = weapon.Slot,
                    Type = weapon.Type
                });

            return new OperatorDto
            {
                Name = @operator.Name,
                Weapons = weaponDtos
            };
        }
    }
}