using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using aspBattleArena.Models;
using Azure.Core;

namespace aspBattleArena.Views.ViewModels;

public class BaseViewModel
{
    [Required]
    [Display(Name = "Name")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$",ErrorMessage = "The name must contatin only letters")]
    
    public string Name { get; set; }
    [Required]
    [Display(Name = "Address")]
    public string Address { get; set; }
    [Display(Name = "Name of Organization")]
    public string OrganizationName { get; set; }
}