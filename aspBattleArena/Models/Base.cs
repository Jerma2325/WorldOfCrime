using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aspBattleArena.Data;
using Microsoft.EntityFrameworkCore;

namespace aspBattleArena.Models;

public class Base
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BaseID { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public Organization Organization { get; set; }

    public Base()
    {
        
    }

    //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //{

    //}
    //public DbSet<Boss> Bosses { get; set; }
    //public DbSet<Organization> Organizations { get; set; }
    //public DbSet<Base> Bases { get; set; }
    //public DbSet<GangMember> GangMembers { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Boss>().HasMany(b => b.Ogranizations);
    //    modelBuilder.Entity<Organization>().HasOne(o => o.Boss);
    //    modelBuilder.Entity<Organization>().HasMany(o => o.Members);
    //    modelBuilder.Entity<Organization>().HasMany(o => o.Bases);
    //    modelBuilder.Entity<Base>().HasOne(b => b.Organization);
    //    modelBuilder.Entity<GangMember>().HasOne(g => g.Organization);
    //}
}