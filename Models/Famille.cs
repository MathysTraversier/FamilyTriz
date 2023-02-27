using System.ComponentModel.DataAnnotations;

namespace MvcFamilyTriz.Models;

public class Famille {
    public int id {get; set;}
    
    [Display(Name = "Famille")]
    public string couleur {get; set;} = null!;
    
    [Display(Name = "Point(s)")]
    public int points {get; set;}

    public List<Eleve> Eleves {get;set;} = new();

}