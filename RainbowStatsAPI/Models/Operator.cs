using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RainbowStatsAPI.Models
{
    public class Operator
    {
        [Key]
        public string Name { get; set; }

        public ICollection<Weapon> Weapons { get; set; }
    }
}