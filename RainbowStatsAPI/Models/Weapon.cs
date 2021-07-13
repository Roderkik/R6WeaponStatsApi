using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace RainbowStatsAPI.Models
{
    public class Weapon
    {
        [Key] public string Name { get; set; }

        public string Type { get; set; }
        public string Action { get; set; }
        public string Slot { get; set; }
        public int Rpm { get; set; }

        [NotMapped] public double[] DamageRanges { get; set; }

        public string SerializedDamageRanges
        {
            get => JsonSerializer.Serialize(DamageRanges);
            set => DamageRanges = JsonSerializer.Deserialize<double[]>(value);
        }

        public ICollection<Operator> Operators { get; set; }
    }
}