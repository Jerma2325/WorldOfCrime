using System.Data.Entity;
using System.Diagnostics;
using aspBattleArena.Models;


namespace aspBattleArena.Data;

public class DbInitializer: CreateDatabaseIfNotExists<AppDbContext>
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();
        
        if (context.Bosses.Any())
        {
            return;
        }

        context.Add(new Boss
            { BossId = 1, Age = 81, FirstName = "Kenichi", LastName = "Shinoda", Nationality = Nationality.Japanese, });
        context.SaveChanges();

        context.Add(new Organization
            { Boss = context.Bosses.FirstOrDefault(b=>b.BossId ==1), CountryOfOrigin = "Japan", Name = "Yakudza", OgranizationId = 1 });
        context.SaveChanges();
        var gangmemebers = new GangMember[]
        {
            new GangMember
            {
                MemberId = 1, FirstName = "Yui", LastName = "Nakamura", Endurance = 3, Intelligence = 5, Luck = 2,
                Nationality = Nationality.Japanese, 
                Organization = context.Organizations.FirstOrDefault(o =>o.Name=="Yakudza" ), Strength = 10
            },
            new GangMember 
            {
                MemberId = 2, FirstName = "Akira",LastName = "Tanaka",Endurance = 5,Intelligence = 4, 
                Luck = 6, Strength = 5, Nationality = Nationality.Japanese, 
                Organization = context.Organizations.FirstOrDefault(o=>o.Name== "Yakudza")
            }
        };
        foreach (var member  in gangmemebers)
        {
            context.GangMembers.Add(member);
        }

        context.SaveChanges();
        context.Add(new Base
        {
            Adress = "Łobzowska 36, 31-139, Kraków", BaseID = 1, Name = "Pierogarnia",
            Organization = context.Organizations.FirstOrDefault(o => o.Name == "Yakudza")
        });
        context.SaveChanges();
    }
   
}