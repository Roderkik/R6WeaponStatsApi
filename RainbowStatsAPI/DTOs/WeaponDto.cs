using System.Collections.Generic;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.DTOs
{
    public class WeaponDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Slot { get; set; }
        public int Rpm { get; set; }
        public double[] DamageRanges { get; set; }
        public ICollection<OperatorDto> Operators { get; set; }

        public static ICollection<WeaponDto> Index(ICollection<Weapon> weapons)
        {
            var index = new List<WeaponDto>();

            foreach (Weapon weapon in weapons)
                index.Add(new WeaponDto
                {
                    Action = weapon.Action,
                    DamageRanges = weapon.DamageRanges,
                    Name = weapon.Name,
                    Rpm = weapon.Rpm,
                    Slot = weapon.Slot,
                    Type = weapon.Type
                });

            return index;
        }

        public static WeaponDto Get(Weapon weapon)
        {
            var operatorDtos = new List<OperatorDto>();

            foreach (Operator @operator in weapon.Operators) operatorDtos.Add(new OperatorDto {Name = @operator.Name});

            return new WeaponDto
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