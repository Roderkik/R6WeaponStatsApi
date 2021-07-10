using System.Collections.Generic;

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

        public static ICollection<WeaponDto> Index(ICollection<Models.Weapon> weapons)
        {
            var index = new List<WeaponDto>();

            foreach (Models.Weapon weapon in weapons)
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

        public static WeaponDto Get(Models.Weapon weapon)
        {
            var operatorDtos = new List<OperatorDto>();

            foreach (Models.Operator @operator in weapon.Operators)
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