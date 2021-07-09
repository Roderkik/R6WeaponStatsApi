using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RainbowStatsAPI.Models;

namespace RainbowStatsAPI
{
    public class RainbowStatsContext : DbContext, IRainbowStatsContext
    {
        public RainbowStatsContext(DbContextOptions<RainbowStatsContext> dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Operator> Operators { get; set; }
    }

    public interface IRainbowStatsContext
    {
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Operator> Operators { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
