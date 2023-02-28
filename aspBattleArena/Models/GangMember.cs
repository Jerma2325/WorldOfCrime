using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspBattleArena.Models;

public class GangMember
{
    [Key]
    public int MemberId { get; set; }
    [Required(ErrorMessage = "Member need to have the first name")]
    [Display(Name="Fist Name")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "First name must contatin only letters")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Member need to have the last name")]
    [Display(Name="Last Name")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "Last name must contatin only letters")]
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