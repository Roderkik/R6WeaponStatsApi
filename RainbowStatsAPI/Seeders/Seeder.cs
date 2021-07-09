using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI.Seeders
{
    public class Seeder
    {
        protected static readonly ICollection<Weapon> Json = ImportWeapons();

        private static ICollection<Weapon> ImportWeapons()
        {
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            
            var weapons = JsonSerializer.Deserialize<ICollection<Weapon>>(File.ReadAllText("SiegeWeapons.json"), serializerOptions);

            if (weapons == null)
            {
                throw new FileNotFoundException("SiegeWeapons.json could not be read.");
            }

            return weapons;
        }
    }
}