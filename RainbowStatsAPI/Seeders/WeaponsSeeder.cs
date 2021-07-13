using System;
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
                        DamageRanges = SmoothenDamageRanges(weapon.DamageRanges),
                        // DamageRanges = weapon.DamageRanges,
                        Slot = weapon.Slot,
                        Type = weapon.Type
                    };

                    context.Weapons.Add(contextWeapon);
                }

                context.SaveChanges();
            }
        }

        // PRB92 starts at
        // 12m (42 damage) ends at
        // 23m (25 damage)
        public static double[] SmoothenDamageRanges(double[] damageRanges)
        {
            // 1. Find the first damage dropoff, remember index.
            // 2. Find the next damage that's equal to previous damage, remember index.
            // 3. Find difference of value between 1.index and 2.index
            // 4. Find distance between 1.index and 2.index
            // 5. Divide difference of value of indexes by distance between indexes, remember result.
            // 6. Start at first damage dropoff lowering damage ranges multiplied by distance to damage dropoff 

            var firstDropOffFound = false;
            var lastDropOffFound = false;

            var firstDropOffIndex = 0;
            var lastDropOffIndex = 0;

            double damageLow = 0;
            double damageHigh = 0;

            double deltaDamage;
            int deltaDistance;

            double damageStep;

            for (var i = 0; i < damageRanges.Length - 1; i++)
                // 1. Find the first damage drop off, remember index
                if (!firstDropOffFound)
                {
                    if (damageRanges[i] > damageRanges[i + 1])
                    {
                        firstDropOffFound = true;
                        damageHigh = damageRanges[i];
                        firstDropOffIndex = i + 1;
                    }
                }
                else
                {
                    break;
                }

            for (var i = damageRanges.Length - 1; i > 0; i--)
                // 2. Find the earliest index that is equal to the last index, remember index.
                if (!lastDropOffFound)
                {
                    if (damageRanges[i] < damageRanges[i - 1])
                    {
                        lastDropOffFound = true;
                        damageLow = damageRanges[i];
                        lastDropOffIndex = i;
                    }
                }
                else
                {
                    break;
                }

            if (!firstDropOffFound || !lastDropOffFound) throw new Exception("Yeah it still ain't working bud.");

            // 3. Find difference of value between 1.index and 2.index
            deltaDamage = damageHigh - damageLow;
            // 4. Find distance between 1.index and 2.index
            deltaDistance = lastDropOffIndex - firstDropOffIndex;
            // 5. Divide difference of value of indexes by distance between indexes, remember result.
            damageStep = deltaDamage / deltaDistance;

            // 6. Start at first damage drop off lowering damage ranges multiplied by distance to damage drop off
            for (var i = firstDropOffIndex; i < lastDropOffIndex; i++)
                damageRanges[i] = damageHigh - (i - firstDropOffIndex) * damageStep;

            // this should work COPIUM
            return damageRanges;
        }
    }
}