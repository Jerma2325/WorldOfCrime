using System.ComponentModel.DataAnnotations;
using aspBattleArena.Models;

namespace aspBattleArena.Views.ViewModels;

public class OrganizationViewModel
{
    public int OrganizationId { get; set; }
    [Required(ErrorMessage = "Enter a name for a base" )]
    [Display(Name = "Name")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$",ErrorMessage = "The name must contatin only letters")]
    public string Name { get; set; }
    [Display(Name = "Country of Origin")]
    public string CountryOfOrigin { get; set; }
    [Display(Name = "Boss")]
    public int BossID { get; set; }
    public  Boss Boss { get; set; }
    

    
}