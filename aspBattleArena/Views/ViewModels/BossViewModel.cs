using System.ComponentModel.DataAnnotations;
using Azure.Core;

namespace aspBattleArena.Views.ViewModels;

public class BossViewModel
{
   
    [Required]
    [Display(Name="Fist Name")]
    public string FirstName { get; set; }
    [Required]
    [Display(Name="Last Name")]
    public string LastName { get; set; }
    
    [Display(Name="Age")]
    public int Age { get; set; }
    [Display(Name = "Nationality")]
    public string Nationality { get; set; }
    [Display(Name = "Organization")]
    public  string Ogranization { get; set; }

}