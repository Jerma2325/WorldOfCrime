using System.ComponentModel.DataAnnotations;
using aspBattleArena.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aspBattleArena.Views.ViewModels;

public class BossViewModel
{
   public  int BossId { get; set; }
    [Required]
    [Display(Name="Fist Name")]
    public string FirstName { get; set; }
    [Required]
    [Display(Name="Last Name")]
    public string LastName { get; set; }
    
    [Display(Name="Age")]
    public int Age { get; set; }
    [Display(Name = "Nationality")]
    public Nationality Nationality { get; set; }
    [Display(Name = "Organization")]
    public  string Organization { get; set; }
    public Organization Organizations { get; set; }

}