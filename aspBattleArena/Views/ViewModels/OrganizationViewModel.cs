using System.ComponentModel.DataAnnotations;
using aspBattleArena.Models;

namespace aspBattleArena.Views.ViewModels;

public class OrganizationViewModel
{
    public int OrganizationId { get; set; }
    [Microsoft.Build.Framework.Required]
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Display(Name = "Country of Origin")]
    public string CountryOfOrigin { get; set; }
    [Display(Name = "Boss")]
    public int BossID { get; set; }
    public  Boss Boss { get; set; }
    

    
}