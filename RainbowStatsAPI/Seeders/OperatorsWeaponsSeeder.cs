using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.Seeders
{
    public class OperatorsWeaponsSeeder : Seeder
    {
        public static void Seed(RainbowStatsContext context)
        {
            bool filled = context.Weapons
                .Include(w => w.Operators)
                .Any(w => w.Operators.Count > 0);
            
            if (!filled)
            {
                foreach (Weapon weapon in Json)
                {
                    Weapon contextWeapon = context.Weapons
                        .Include(w => w.Operators)
                        .FirstOrDefault(w => w.Name == weapon.Name);

                    foreach (Operator @operator in weapon.Operators)
                    {
                        if (contextWeapon != null)
                        {
                            contextWeapon.Operators.Add(context.Operators.Find(@operator.Name));
                        }
                        else
                        {
                            
                        }
                    }
                }

                context.SaveChanges();
            }
        }
    }
}