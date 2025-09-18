using Cronache_di_DnD.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cronache_di_DnD;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<UserEntity> Users { get; set; }
}