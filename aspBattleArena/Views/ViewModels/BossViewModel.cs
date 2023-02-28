using System.ComponentModel.DataAnnotations;
using aspBattleArena.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aspBattleArena.Views.ViewModels;

public class BossViewModel
{
   public  int BossId { get; set; }
    [Required(ErrorMessage = "Boss need to have the first name")]
    [Display(Name="Fist Name")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "First name must contatin only letters")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Boss need to have the last name")]
    [Display(Name="Last Name")]
    [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage = "Last name must contatin only letters")]
    public string LastName { get; set; }
    
    [Display(Name="Age")]
    public int Age { get; set; }
    [Display(Name = "Nationality")]
    public Nationality Nationality { get; set; }
    [Display(Name = "Organization")]
    public  string Organization { get; set; }
    public Organization Organizations { get; set; }

}