using aspBattleArena.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace aspBattleArena.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    
    public DbSet<Boss> Bosses { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Base> Bases { get; set; }
    public DbSet<GangMember> GangMembers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boss>().HasMany(b => b.Ogranizations);
        modelBuilder.Entity<Organization>().HasOne(o => o.Boss);
        modelBuilder.Entity<Organization>().HasMany(o => o.Members);
        modelBuilder.Entity<Organization>().HasMany(o => o.Bases);
        modelBuilder.Entity<Base>().HasOne(b => b.Organization);
        modelBuilder.Entity<GangMember>().HasOne(g => g.Organization);

        //modelBuilder.Entity<Boss>(entity =>
        //{
        //    entity.HasKey(e => e.BossId);
        //    entity.Property(e => e.BossId);
        //    entity.Property(e => e.FirstName).HasMaxLength(250);
        //    entity.Property(e => e.LastName).HasMaxLength(250);
        //    entity.Property(e => e.Nationality);
        //    entity.Property(e => e.Age);

        //    entity.HasData(new Boss
        //    { BossId = 1, Age = 81, FirstName = "Kenichi", LastName = "Shinoda", Nationality = Nationality.Japanese, });
        //});
    } 
}