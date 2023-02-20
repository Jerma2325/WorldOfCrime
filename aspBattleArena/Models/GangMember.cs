using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspBattleArena.Models;

public class GangMember
{
    [Key]
    public int MemberId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public  Nationality Nationality { get; set; }
    public Organization Organization { get; set; }
    public int Strength { get; set; }
    public int Endurance { get; set; }
    public int Intelligence { get; set; }
    public int Luck { get; set; }

    public GangMember()
    {
        
    }
}