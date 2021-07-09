using System.Collections.Generic;
using System.Linq;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.Seeders
{
    public class OperatorsSeeder : Seeder
    {
        private static readonly List<Operator> Operators = new();

        public static void Seed(RainbowStatsContext context)
        {
            if (!context.Operators.Any())
            {
                foreach (Weapon weapon in Json)
                {
                    foreach (Operator @operator in weapon.Operators)
                    {
                        if (Operators.All(o => o.Name != @operator.Name))
                        {
                            Operators.Add(@operator);
                        }
                    }
                }
                
                context.AddRange(Operators);
                context.SaveChanges();
            }
        }
    }
}