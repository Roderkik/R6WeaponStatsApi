using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.DTOs
{
    public static class Weapons
    {
        public static ICollection<WeaponDto> Index(ICollection<Weapon> weapons)
        {
            var index = new List<WeaponDto>();

            foreach (Weapon weapon in weapons)
            {
                index.Add(new WeaponDto
                {
                    Action = weapon.Action,
                    DamageRanges = weapon.DamageRanges,
                    Name = weapon.Name,
                    Rpm = weapon.Rpm,
                    Slot = weapon.Slot,
                    Type = weapon.Type
                });
            }

            return index;
        }

        public static WeaponDto Get(Weapon weapon)
        {
            var operatorDtos = new List<OperatorDto>();

            foreach (Operator @operator in weapon.Operators)
            {
                operatorDtos.Add(new OperatorDto() { Name = @operator.Name});
            }
            
            return new WeaponDto()
            {
                Action = weapon.Action,
                DamageRanges = weapon.DamageRanges,
                Name = weapon.Name,
                Rpm = weapon.Rpm,
                Slot = weapon.Slot,
                Type = weapon.Type,
                Operators = operatorDtos
            };
        }
    }
}