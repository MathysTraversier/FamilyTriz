using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcFamilyTriz.Models;

public class Eleve {
    public int id {get; set;}
    
    [Display(Name = "Nom")]
    public string nom {get; set;} = null!;

    [Display(Name = "Prénom")]
    public string prenom {get; set;} = null!;

    [Display(Name = "Promotion")]
    public int promotion {get; set;}

    public int? parrainId {get; set;}

    public int familleId {get; set;}

    [Display(Name = "Parrain/Marraine")]
    public Eleve? parrain {get; set;}

    [Display(Name = "Famille")]
    public Famille famille {get; set;} = null!;

}