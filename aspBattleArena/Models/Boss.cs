using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace aspBattleArena.Models;

public class Boss
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BossId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Nationality Nationality { get; set; }
    public  IList<Organization> Ogranizations { get; set; }

    public Boss()
    {
        Ogranizations = new List<Organization>();
    }

}