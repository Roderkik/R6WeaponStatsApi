using System.Linq;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.Seeders
{
    public class WeaponsSeeder : Seeder
    {
        public static void Seed(RainbowStatsContext context)
        {
            if (!context.Weapons.Any())
            {
                // Add weapons
                foreach (Weapon weapon in Json)
                {
                    var contextWeapon = new Weapon
                    {
                        Action = weapon.Action,
                        Name = weapon.Name,
                        Rpm = weapon.Rpm,
                        DamageRanges = weapon.DamageRanges,
                        Slot = weapon.Slot,
                        Type = weapon.Type,
                    };
                    
                    context.Weapons.Add(contextWeapon);
                }

                context.SaveChanges();
            }
        }
    }
}